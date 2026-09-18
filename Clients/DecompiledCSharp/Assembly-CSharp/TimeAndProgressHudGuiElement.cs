using System.Text;
using UnityEngine;

public class TimeAndProgressHudGuiElement : GuiElement
{
	[Header("TOP Mission Progress")]
	public GameObject progressPart;

	public UISprite progressBackground;

	public UISprite progressSprite;

	public UILabel progressLabel;

	[Header("TOP RIGHT Time Progress")]
	public GameObject timePart;

	public UILabel timeLabel;

	public UILabel lowTimeLabel;

	public UISprite lowTimeBackground;

	[Header("Bootcamp")]
	public GameObject bootcampPart;

	public UILabel bootcampLabel;

	private bool mUpdateProgress;

	private bool mUpdateTime;

	private bool mTimeWarningShown;

	private int mOvertimeAlarmSoundNum = 5;

	private Vector3 mBootcampPosition;

	private float mProgressWidth;

	private StringBuilder mTimeText = new StringBuilder(8);

	protected override void Awake()
	{
		base.Awake();
		lowTimeBackground.transform.localScale = lowTimeBackground.transform.localScale.ReplaceX(lowTimeLabel.relativeSize.x * lowTimeLabel.transform.localScale.x + 16f);
	}

	public override void InitControls()
	{
		mProgressWidth = (UIRoot.list[0].activeWidth / 2f - 140f) / GuiScreenSingle<HudScreen>.instance.transform.localScale.x;
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(mProgressWidth);
		progressSprite.transform.localPosition = progressSprite.transform.localPosition.ReplaceX(0f - (mProgressWidth - 16f));
		progressSprite.transform.localScale = progressSprite.transform.localScale.ReplaceX(mProgressWidth - 16f);
		progressSprite.mFillSlopePixels = 364f / (mProgressWidth - 16f);
		progressSprite.fillAmount = 0f;
		progressLabel.transform.localPosition = progressLabel.transform.localPosition.ReplaceX(-0.5f * mProgressWidth);
		mProgressWidth += 20f;
		mBootcampPosition = bootcampPart.transform.localPosition;
		Singleton<GameController>.instance.GameStarted += InstanceGameStarted;
		Singleton<GameController>.instance.GameEnded += InstanceGameEnded;
		Singleton<MatchManager>.instance.OverTimeStarted += OnOverTimeStart;
		Hide();
	}

	public override void InitGUIValues()
	{
	}

	private void InstanceGameStarted()
	{
		Show();
		HideTimeWarning();
		StopOvertime();
		bootcampPart.SetActive(Singleton<GameController>.instance.isTutorial);
		if (Singleton<GameController>.instance.isTutorial)
		{
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				bootcampLabel.text = Localization.LocalizeFormat("ID_TUTORIAL_PHASE", 1, 3);
			}
			else if (Singleton<GameController>.instance.isTutorialStage2)
			{
				bootcampLabel.text = Localization.LocalizeFormat("ID_TUTORIAL_PHASE", 2, 3);
			}
			else if (Singleton<GameController>.instance.isTutorialStage3)
			{
				bootcampLabel.text = Localization.LocalizeFormat("ID_TUTORIAL_PHASE", 3, 3);
			}
		}
		bootcampPart.transform.localPosition = mBootcampPosition;
		timeLabel.text = string.Empty;
		mOvertimeAlarmSoundNum = 5;
	}

	private void InstanceGameEnded(GameController.GameEndReason endReason)
	{
		StopOvertime();
		HideTimeWarning();
		Hide();
	}

	private void OnOverTimeStart()
	{
		StartOvertime();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Overtime);
	}

	private void Show()
	{
		bool flag = Singleton<GameController>.instance.isCampaignBot || Singleton<GameController>.instance.isCoopBot;
		if (Singleton<GameController>.instance.isMission && !flag)
		{
			progressPart.SetActive(value: true);
			mUpdateProgress = true;
		}
		timePart.SetActive(value: true);
		mUpdateTime = true;
	}

	private void Hide()
	{
		progressPart.SetActive(value: false);
		timePart.SetActive(value: false);
		mUpdateProgress = false;
		mUpdateTime = false;
	}

	private void ShowTimeWarning()
	{
		if (!mTimeWarningShown)
		{
			mTimeWarningShown = true;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(lowTimeBackground.gameObject, 0.5f, 0f, 0.8f);
			tweenAlpha.style = UITweener.Style.PingPong;
			tweenAlpha.NumOfRepetitions = 0;
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(lowTimeLabel.gameObject, 0f, 0f, 1f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void HideTimeWarning()
	{
		mTimeWarningShown = false;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(lowTimeBackground.gameObject, 0f, 0f, 0f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 1;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(lowTimeLabel.gameObject, 0f, 0f, 0f);
		tweenAlpha2.style = UITweener.Style.Once;
		tweenAlpha2.NumOfRepetitions = 1;
	}

	private void PlayOvertimeAlarmSound()
	{
		if (Singleton<GameController>.instance.time <= (float)mOvertimeAlarmSoundNum && Singleton<GameController>.instance.time >= 0f && mOvertimeAlarmSoundNum > 0)
		{
			mOvertimeAlarmSoundNum--;
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OvertimeAlarm);
		}
	}

	private void StartOvertime()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(timeLabel.gameObject, 0.5f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void StopOvertime()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(timeLabel.gameObject, 0.05f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 1;
	}

	protected override void Update()
	{
		if (mUpdateProgress)
		{
			progressLabel.text = MissionsManager.instance.missionHudObjective;
			progressSprite.fillAmount = MissionsManager.instance.missionProgress;
		}
		if (!mUpdateTime)
		{
			return;
		}
		mTimeText.Length = 0;
		Singleton<GameController>.instance.mainController.GetTimeProgressText(mTimeText);
		if (Singleton<GameController>.instance.isMission)
		{
			if (!(MissionsManager.instance.currentMission is SurviveMission))
			{
				if (MissionsManager.instance.time < 10f)
				{
					ShowTimeWarning();
				}
				else if (mTimeWarningShown)
				{
					HideTimeWarning();
				}
			}
		}
		else if (Singleton<GameController>.instance.isPVP)
		{
			if (Singleton<MatchManager>.instance.isOverTime)
			{
				HideTimeWarning();
			}
			else
			{
				PlayOvertimeAlarmSound();
				if (Singleton<GameController>.instance.time < 10f && Singleton<GameController>.instance.time > 0f)
				{
					ShowTimeWarning();
				}
			}
		}
		timeLabel.text = mTimeText.ToString();
	}
}
