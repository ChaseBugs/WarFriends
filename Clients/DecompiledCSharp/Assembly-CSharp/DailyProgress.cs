using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyProgress : Core_BaseScript
{
	[Header("Core")]
	public UITable table;

	public DayRecord dayProgressPrefab;

	public GameObject rewardBox;

	public GameObject infoButton;

	public UISprite boxIcon;

	[Header("-Claim Button")]
	public GameObject claimButton;

	public BoxCollider claimButtonCollider;

	public UISprite claimButtonBackground;

	public GameObject claimButtonWaiting;

	[Header("Hint Part")]
	public UIPanel hintPanel;

	public BoxCollider hintCollider;

	public UITable hintTable;

	public UISprite hintDialogBackground;

	public GameObject hintLengthObject;

	public UISprite hintButtonSprite;

	private List<DayRecord> mDayProgresses = new List<DayRecord>();

	private Vector3 mBasicPosition = new Vector3(0f, 0f, 0f);

	private Vector3 mOffScreenPosition = new Vector3(-1600f, 0f, 0f);

	private Vector3 mButtonOffPosition = new Vector3(-200f, 0f, 0f);

	private Vector3 mButtonRightPosition = new Vector3(8f, 0f, 0f);

	private Vector3 mButtonPosition = new Vector3(0f, 0f, 0f);

	public void InitControls()
	{
		mDayProgresses.Clear();
		mDayProgresses.Add(dayProgressPrefab);
		for (int i = 1; i < 7; i++)
		{
			DayRecord dayRecord = UnityEngine.Object.Instantiate(dayProgressPrefab);
			if (dayRecord != null)
			{
				dayRecord.transform.parent = dayProgressPrefab.transform.parent;
				mDayProgresses.Add(dayRecord);
			}
			else
			{
				Debug.LogError("Not enought memory for instantiating prefab");
			}
		}
		int count = mDayProgresses.Count;
		for (int j = 0; j < count; j++)
		{
			mDayProgresses[j].gameObject.name = $"{j} Day Progress";
			mDayProgresses[j].transform.localScale = Vector3.one;
			mDayProgresses[j].transform.localPosition = new Vector3(78f * (float)j, 0f, 0f);
			mDayProgresses[j].Initialize(dayCompleted: false, fillNextProgress: false);
		}
		rewardBox.transform.localPosition = new Vector3(78f * (float)count + 14f, 0f, 0f);
		hintTable.repositionNow = true;
		UITable uITable = hintTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(OnHintReposition));
		hintPanel.gameObject.SetActive(value: false);
		table.repositionNow = true;
		table.onReposition = delegate
		{
			float z = hintPanel.transform.localPosition.z;
			hintPanel.transform.position = infoButton.transform.position;
			hintPanel.transform.localPosition = new Vector3(hintPanel.transform.localPosition.x, -56f, z);
		};
		UIEventListener uIEventListener = UIEventListener.Get(infoButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(InfoClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(claimButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ClaimClicked));
		UIEventListener.Get(hintPanel.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HideHint();
		};
	}

	private void OnHintReposition()
	{
		float num = Mathf.Abs(hintLengthObject.transform.localPosition.y);
		hintDialogBackground.transform.localScale = hintDialogBackground.transform.localScale.ReplaceY(num + 60f);
		hintCollider.center = hintCollider.center.ReplaceY((0f - num) / 2f - 30f);
		hintCollider.size = hintCollider.size.ReplaceY(num + 100f);
	}

	private void InfoClicked(GameObject go)
	{
		Debug.Log("Assignment Screen - Daily - Info Clicked");
		SoundsManager.Instance.PlayButtonClickedSound();
		if (hintPanel.gameObject.activeSelf)
		{
			HideHint();
		}
		else
		{
			ShowHint();
		}
	}

	private void HideHint()
	{
		hintButtonSprite.spriteName = MiscTools.infoButtonSprite;
		TweenAlpha.Begin(hintPanel.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(hintPanel.gameObject, 0.4f, new Vector3(hintPanel.transform.localPosition.x, -36f, hintPanel.transform.localPosition.z));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			hintPanel.gameObject.SetActive(value: false);
		};
	}

	private void ShowHint()
	{
		hintButtonSprite.spriteName = MiscTools.closeButtonSprite;
		hintPanel.gameObject.SetActive(value: true);
		hintPanel.alpha1 = 0.005f;
		TweenAlpha.Begin(hintPanel.gameObject, 0.4f, 1f).onFinished = null;
		hintPanel.transform.localPosition = new Vector3(hintPanel.transform.localPosition.x, -76f, hintPanel.transform.localPosition.z);
		TweenPosition tweenPosition = TweenPosition.Begin(hintPanel.gameObject, 0.25f, hintPanel.transform.localPosition.ReplaceY(-76f), hintPanel.transform.localPosition.ReplaceY(-46f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(hintPanel.gameObject, 0.15f, hintPanel.transform.localPosition.ReplaceY(-56f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void ClaimClicked(GameObject go)
	{
		Debug.Log("Assignment Screen - Daily - Claim Clicked");
		SetClaimButton(active: false);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.AssignmentMegaReward);
		Singleton<BeanstalkServerManager>.instance.ClaimAssignmentMegaReward();
	}

	private void SetClaimButton(bool active, bool setPosition = true, bool scaleAnimation = true)
	{
		claimButtonCollider.enabled = active;
		claimButtonBackground.color = ((!active) ? Colours.grayButton : Color.white);
		claimButtonWaiting.SetActive(!active);
		hintCollider.center = ((!active) ? new Vector3(0f, 0.5f, -1f) : new Vector3(0f, 0f, -1f));
		hintCollider.size = ((!active) ? new Vector3(3f, 3f, 1f) : new Vector3(3f, 2f, 1f));
		if (setPosition)
		{
			TweenPosition.Begin(claimButton, 0f, (!active) ? mButtonOffPosition : mButtonPosition).onFinished = null;
		}
		if (scaleAnimation)
		{
			if (active)
			{
				LoopingScaleAnimation();
			}
			else
			{
				EndOfScaleAnimation();
			}
		}
	}

	private void LoopingScaleAnimation()
	{
		Vector3 vector = new Vector3(94f, 95f, 1f);
		TweenScale tweenScale = TweenScale.Begin(boxIcon.gameObject, 0.75f, vector, vector.MultiplyXY(1.1f));
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 0;
	}

	private void EndOfScaleAnimation(bool instant = false)
	{
		float duration = ((!instant) ? 0.2f : 0.01f);
		TweenScale tweenScale = TweenScale.Begin(boxIcon.gameObject, duration, new Vector3(94f, 95f, 1f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	public void Initialize()
	{
		int completedDaysAssignments = AssignmentsManager.instance.completedDaysAssignments;
		int count = mDayProgresses.Count;
		bool flag = completedDaysAssignments >= count;
		for (int i = 0; i < count; i++)
		{
			mDayProgresses[i].Initialize(i < completedDaysAssignments, i + 1 < completedDaysAssignments);
			mDayProgresses[i].StopAnimations();
		}
		if (flag)
		{
			mDayProgresses[count - 1].Initialize(dayCompleted: true, fillNextProgress: true);
		}
		claimButton.SetActive(flag);
		base.gameObject.SetActive(value: true);
		TweenPosition.Begin(base.gameObject, 0f, mBasicPosition).onFinished = null;
		base.gameObject.SetActive(flag);
		SetClaimButton(flag);
		hintPanel.gameObject.SetActive(value: false);
		hintButtonSprite.spriteName = MiscTools.infoButtonSprite;
	}

	public void EndOfDayProgressAnimation()
	{
		int completedDaysAssignments = AssignmentsManager.instance.completedDaysAssignments;
		int count = mDayProgresses.Count;
		bool flag = completedDaysAssignments >= count;
		for (int i = 0; i < count; i++)
		{
			mDayProgresses[i].Initialize(i < completedDaysAssignments, i + 1 < completedDaysAssignments);
		}
		if (flag)
		{
			float dur = 0.15f;
			mDayProgresses[count - 1].Initialize(dayCompleted: true, fillNextProgress: true);
			claimButton.SetActive(value: true);
			SetClaimButton(active: true, setPosition: false, scaleAnimation: false);
			TweenPosition tweenPosition = TweenPosition.Begin(claimButton, dur * 2f, mButtonOffPosition, mButtonRightPosition);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				LoopingScaleAnimation();
				TweenPosition tweenPosition2 = TweenPosition.Begin(claimButton, dur, mButtonPosition);
				tweenPosition2.method = UITweener.Method.EaseIn;
				tweenPosition2.onFinished = null;
			};
		}
	}

	public void Show()
	{
		float dur = 0.25f;
		float delay = 0.1f;
		base.transform.localPosition = mOffScreenPosition;
		base.gameObject.SetActive(value: true);
		TweenPosition.Begin(claimButton, 0f, mButtonOffPosition).onFinished = null;
		EndOfScaleAnimation(instant: true);
		TweenPosition.Begin(base.gameObject, dur, mOffScreenPosition, mBasicPosition).onFinished = delegate
		{
			int index = Mathf.Clamp(AssignmentsManager.instance.completedDaysAssignments - 1, 0, mDayProgresses.Count - 1);
			mDayProgresses[index].Animate(dur, delay);
		};
	}
}
