using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentsContent : Core_BaseScript
{
	[Header("Left Button")]
	public UISprite assignmentIcon;

	public GameObject notificationObject;

	public UISprite notificationObjectWBIcon;

	public UISprite notificationObjectGoldIcon;

	[Header("Daily")]
	public GameObject dailyPart;

	public List<AssignmentRecord> assignments;

	[Header("Starter")]
	public GameObject starterPart;

	public UILabel timeToCompleteLabel;

	public StarterAssignmentComplete[] completedAssignments;

	public StarterAssignmentRecord currentAssignmentRecord;

	public UILabel rewardsTimeToEndLabel;

	private List<TweenAnimator> mAnimator = new List<TweenAnimator>();

	private TweenAnimator mAnimatorEmpty;

	private TweenAnimator mAnimator1AssignmentProgress;

	private TweenAnimator mAnimator2AssignmentProgress;

	private TweenAnimator mAnimator3AssignmentProgress;

	private TweenAnimator mAnimator1AssignmentCompleted;

	private TweenAnimator mAnimator2AssignmentCompleted;

	private TweenAnimator mAnimator3AssignmentCompleted;

	private FloatObject mAssignment1ProgressStart = new FloatObject(0f);

	private FloatObject mAssignment1ProgressEnd = new FloatObject(0f);

	private FloatObject mAssignment1CompletedStart = new FloatObject(0f);

	private FloatObject mAssignment1CompletedEnd = new FloatObject(0f);

	private FloatObject mAssignment2ProgressStart = new FloatObject(0f);

	private FloatObject mAssignment2ProgressEnd = new FloatObject(0f);

	private FloatObject mAssignment2CompletedStart = new FloatObject(0f);

	private FloatObject mAssignment2CompletedEnd = new FloatObject(0f);

	private FloatObject mAssignment3ProgressStart = new FloatObject(0f);

	private FloatObject mAssignment3ProgressEnd = new FloatObject(0f);

	private FloatObject mAssignment3CompletedStart = new FloatObject(0f);

	private FloatObject mAssignment3CompletedEnd = new FloatObject(0f);

	private bool mShownTab;

	private bool mUpdateStarterAssignments;

	private float mTimer;

	public List<TweenAnimator> Animator => mAnimator;

	public void InitControls()
	{
		InitAnimators();
		assignments[0].InitControls();
		assignments[1].InitControls();
		assignments[2].InitControls();
		AssignmentsManager.instance.AssignmentClaimed += delegate(int index)
		{
			UpdateNotifications();
			List<Assignment> list = AssignmentsManager.instance.GetAssignments(update: false);
			if (list != null && list.Count == 3 && assignments[index].gameObject.activeSelf && !assignments[index].isAnimatingClaim)
			{
				assignments[index].Init(list[index]);
			}
		};
		AssignmentsManager.instance.AssignmentsLoaded += delegate
		{
			if (base.gameObject.activeSelf)
			{
				UpdateAssignments();
			}
		};
		currentAssignmentRecord.InitControls(1476f);
		StarterAssignmentsManager.instance.AssignmentClaimed += AnimateLine;
	}

	private void InitAnimators()
	{
		mAnimator = new List<TweenAnimator>();
		mAnimatorEmpty = EmptyAnimator();
		mAnimator1AssignmentProgress = ProgressAnimator(assignments[0], ref mAssignment1ProgressStart, ref mAssignment1ProgressEnd);
		mAnimator2AssignmentProgress = ProgressAnimator(assignments[1], ref mAssignment2ProgressStart, ref mAssignment2ProgressEnd);
		mAnimator3AssignmentProgress = ProgressAnimator(assignments[2], ref mAssignment3ProgressStart, ref mAssignment3ProgressEnd);
		mAnimator1AssignmentCompleted = CompletedAnimator(assignments[0], ref mAssignment1CompletedStart, ref mAssignment1CompletedEnd);
		mAnimator2AssignmentCompleted = CompletedAnimator(assignments[1], ref mAssignment2CompletedStart, ref mAssignment2CompletedEnd);
		mAnimator3AssignmentCompleted = CompletedAnimator(assignments[2], ref mAssignment3CompletedStart, ref mAssignment3CompletedEnd);
		mAnimator.Add(mAnimatorEmpty);
		mAnimator.Add(mAnimatorEmpty);
		mAnimator.Add(mAnimatorEmpty);
	}

	private TweenAnimator EmptyAnimator()
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		return tweenAnimator;
	}

	private TweenAnimator ProgressAnimator(AssignmentRecord assignmentRecord, ref FloatObject progressStart, ref FloatObject progressEnd)
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		tweenAnimator.AddTween(from: progressStart, id: 1, tweenType: TweenAnimator.TweenType.ProgressBar, tweenTarget: assignmentRecord.progress.gameObject, time: 0.4f, to: progressEnd, delay: 0.4f);
		return tweenAnimator;
	}

	private TweenAnimator CompletedAnimator(AssignmentRecord assignmentRecord, ref FloatObject completedStart, ref FloatObject completedEnd)
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		tweenAnimator.AddTween(from: completedStart, id: 1, tweenType: TweenAnimator.TweenType.ProgressBar, tweenTarget: assignmentRecord.progress.gameObject, time: 0.4f, to: completedEnd, delay: 0.4f);
		tweenAnimator.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 1)
			{
				assignmentRecord.ChangeToCompleted();
			}
		};
		return tweenAnimator;
	}

	private void AnimateLine()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		if (base.gameObject.activeSelf)
		{
			completedAssignments[num - 1].AnimateFinish();
			if (num < StarterAssignmentsManager.instance.assignmentsCount)
			{
				completedAssignments[num].AnimateProgress();
			}
		}
		if (!currentAssignmentRecord.isClaimAnimating)
		{
			currentAssignmentRecord.Initialize(StarterAssignmentsManager.instance.currentAssignment);
		}
		UpdateNotifications();
	}

	internal void InitGuiValues()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			return;
		}
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		dailyPart.SetActive(!isActiveAndNotCompleted);
		starterPart.SetActive(isActiveAndNotCompleted);
		if (isActiveAndNotCompleted)
		{
			StarterAssignmentsManager.instance.Evaluate();
			InitializeStarterAssignmentLook();
			mUpdateStarterAssignments = true;
			mAnimator[0] = mAnimatorEmpty;
			mAnimator[1] = mAnimatorEmpty;
			mAnimator[2] = mAnimatorEmpty;
		}
		else
		{
			List<Assignment> list = AssignmentsManager.instance.GetAssignments(update: false);
			if (list == null || list.Count < 3 || list[0] == null || list[1] == null || list[2] == null)
			{
				assignments[0].gameObject.SetActive(value: false);
				assignments[1].gameObject.SetActive(value: false);
				assignments[2].gameObject.SetActive(value: false);
				return;
			}
			assignments[0].gameObject.SetActive(value: true);
			assignments[0].Init(list[0]);
			assignments[1].gameObject.SetActive(value: true);
			assignments[1].Init(list[1]);
			assignments[2].gameObject.SetActive(value: true);
			assignments[2].Init(list[2]);
			Debug.Log($"End Screen - Assignment tab:\nAssignment1:\t{list[0].GetProgress()}\nAssignment2:\t{list[1].GetProgress()}\nAssignment3:\t{list[2].GetProgress()}\n");
			if (list[0].currentState == Assignment.State.InProgress)
			{
				mAssignment1ProgressStart.val = list[0].GetStartProgress();
				mAssignment1ProgressEnd.val = list[0].GetEndProgress();
				mAnimator[0] = mAnimator1AssignmentProgress;
			}
			else if (list[0].currentState == Assignment.State.Finishing)
			{
				mAssignment1CompletedStart.val = list[0].GetStartProgress();
				mAssignment1CompletedEnd.val = list[0].GetEndProgress();
				mAnimator[0] = mAnimator1AssignmentCompleted;
			}
			else
			{
				mAnimator[0] = mAnimatorEmpty;
			}
			if (list[1].currentState == Assignment.State.InProgress)
			{
				mAssignment2ProgressStart.val = list[1].GetStartProgress();
				mAssignment2ProgressEnd.val = list[1].GetEndProgress();
				mAnimator[1] = mAnimator2AssignmentProgress;
			}
			else if (list[1].currentState == Assignment.State.Finishing)
			{
				mAssignment2CompletedStart.val = list[1].GetStartProgress();
				mAssignment2CompletedEnd.val = list[1].GetEndProgress();
				mAnimator[1] = mAnimator2AssignmentCompleted;
			}
			else
			{
				mAnimator[1] = mAnimatorEmpty;
			}
			if (list[2].currentState == Assignment.State.InProgress)
			{
				mAssignment3ProgressStart.val = list[2].GetStartProgress();
				mAssignment3ProgressEnd.val = list[2].GetEndProgress();
				mAnimator[2] = mAnimator3AssignmentProgress;
			}
			else if (list[2].currentState == Assignment.State.Finishing)
			{
				mAssignment3CompletedStart.val = list[2].GetStartProgress();
				mAssignment3CompletedEnd.val = list[2].GetEndProgress();
				mAnimator[2] = mAnimator3AssignmentCompleted;
			}
			else
			{
				mAnimator[2] = mAnimatorEmpty;
			}
		}
		UpdateNotifications();
		mShownTab = false;
	}

	private void InitializeStarterAssignmentLook()
	{
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < completedAssignments.Length; i++)
		{
			if (i < num)
			{
				completedAssignments[i].SetCompleted();
			}
			else if (i == num)
			{
				completedAssignments[i].SetCurrent();
			}
			else
			{
				completedAssignments[i].SetDefault();
			}
		}
		currentAssignmentRecord.Initialize(currentAssignment);
	}

	public void UpdateTimes()
	{
		if (mUpdateStarterAssignments)
		{
			if (StarterAssignmentsManager.instance.isAllCompleted)
			{
				timeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("ID_COMPLETED");
				rewardsTimeToEndLabel.text = Localization.Localize("ID_YOURREWARDS");
			}
			else
			{
				int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
				if (num == 0)
				{
					timeToCompleteLabel.text = Localization.Localize("ID_EXPIRED");
					rewardsTimeToEndLabel.text = Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED");
				}
				else
				{
					timeToCompleteLabel.text = string.Format("{0} {1}{2}", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty), Colours.stringWhite, Localization.Localize("ID_TOCOMPLETE"));
					rewardsTimeToEndLabel.text = Localization.LocalizeFormat("ID_COMPLETEALLTENSTARTERASSIGNMENTS", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty));
				}
			}
		}
		mUpdateStarterAssignments = StarterAssignmentsManager.instance.isActive;
	}

	public void Update()
	{
		mTimer += Time.deltaTime;
		if (mTimer >= 0.333f)
		{
			mTimer -= 0.333f;
			UpdateTimes();
		}
	}

	public void AnimateShow(float fadeInTime)
	{
	}

	private void UpdateNotifications()
	{
		bool flag = false;
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted && Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications() > 0)
		{
			List<Assignment> list = AssignmentsManager.instance.GetAssignments(update: false);
			foreach (Assignment item in list)
			{
				if (item.currentState != Assignment.State.InProgress)
				{
					flag = true;
				}
			}
			notificationObject.SetActive(value: true);
			notificationObjectGoldIcon.gameObject.SetActive(value: true);
			notificationObjectWBIcon.gameObject.SetActive(value: false);
		}
		else if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			notificationObject.SetActive(value: true);
			notificationObjectWBIcon.gameObject.SetActive(StarterAssignmentsManager.instance.isWBReward);
			notificationObjectGoldIcon.gameObject.SetActive(!notificationObjectWBIcon.gameObject.activeSelf);
		}
		else
		{
			notificationObject.SetActive(value: false);
		}
		assignmentIcon.color = ((!flag) ? Color.white : Colours.yellowAssignemnt);
	}

	public void UpdateAssignments()
	{
		foreach (AssignmentRecord assignment in assignments)
		{
			assignment.UpdateAssignmentLook(!mShownTab);
		}
		if (mShownTab)
		{
			UpdateNotifications();
		}
		if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			InitializeStarterAssignmentLook();
		}
		mShownTab = true;
	}

	public void ResetAssignments()
	{
		AssignmentsManager.instance.FakeAssignments();
		InitGuiValues();
		ResetAnimation();
		UpdateAssignments();
		StartCoroutine(PlayTabAnimator());
	}

	private IEnumerator PlayTabAnimator()
	{
		foreach (TweenAnimator tweenAnimator in mAnimator)
		{
			if (tweenAnimator.allTweens.Count > 0)
			{
				tweenAnimator.PlayTweens();
				yield return new WaitForSeconds(0.3f);
			}
		}
	}

	internal void ResetAnimation()
	{
		foreach (TweenAnimator item in mAnimator)
		{
			item.ResetTweens();
		}
	}

	internal void FinishAnimation()
	{
		foreach (TweenAnimator item in mAnimator)
		{
			item.FinishTweens();
		}
	}

	public void DoAfterHide()
	{
		AssignmentsManager.instance.AssignmentHide();
	}
}
