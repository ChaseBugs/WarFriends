using System;
using UnityEngine;

public class WarpathButton : Core_BaseScript
{
	public enum Type
	{
		Locked,
		Normal,
		Heroic
	}

	[Header("Core")]
	public GameObject trainingButton;

	public UISprite border;

	public UIButtonScale trainingButtonScale;

	[Header("Locked Part")]
	public GameObject lockedWarpath;

	public UILabel lockedTillLevel;

	[Header("Unlocked Part")]
	public GameObject unlockedWarpath;

	public GameObject warpathNotification;

	[Header("Heroic Part")]
	public GameObject heroicWarpath;

	public UIPanel heroicPanel;

	public UILabel heroicMissionLabel;

	public UISprite leftWing;

	public UISprite rightWing;

	public UISprite leftSkull;

	public UISprite rightSkull;

	public UILabel completedLabel;

	public GameObject getPart;

	public UILabel getLabel;

	public UISprite goldSprite;

	public UISprite warbucksSprite;

	public GameObject heroicWarpathNotification;

	private bool mInitialized;

	private float mNotActiveAlpha = 0.75f;

	private Type mCurrentType
	{
		get
		{
			if (LevelManager.instance.isWarpathLocked)
			{
				return Type.Locked;
			}
			if (MissionsManager.instance.isHeroicLocked)
			{
				return Type.Normal;
			}
			return Type.Heroic;
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(trainingButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(TrainingClick));
		InitializeHeroicLook();
	}

	private void TrainingClick(GameObject go)
	{
		if (DebugSettings.debugEnabled || mCurrentType != Type.Locked)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<GameController>.instance.SwitchToSinglePlayer();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MissionScreen>.instance);
		}
	}

	public void InitGuiValues()
	{
		SetLook();
		SetButton();
		InitializeLook();
	}

	public void AnimateShow()
	{
		bool isHeroicMissionCompleted = MissionsManager.instance.isHeroicMissionCompleted;
		TweenAlpha.Begin(heroicPanel.gameObject, GuiScreenSingle<BattlePreparationScreen>.instance.fadeInTime, 0f, (!isHeroicMissionCompleted) ? 1f : mNotActiveAlpha);
	}

	private void SetLook()
	{
		Type type = mCurrentType;
		border.alpha = ((type != Type.Locked) ? 1f : 0.2f);
		lockedWarpath.SetActive(type == Type.Locked);
		unlockedWarpath.SetActive(type == Type.Normal);
		heroicWarpath.SetActive(type == Type.Heroic);
	}

	private void SetButton()
	{
		bool flag = mCurrentType == Type.Locked;
		trainingButtonScale.hover = ((!flag) ? new Vector3(1.1f, 1.1f, 1f) : Vector3.one);
		trainingButtonScale.pressed = ((!flag) ? new Vector3(1.05f, 1.05f, 1f) : Vector3.one);
	}

	public void InitBlank()
	{
		SetLook();
		warpathNotification.SetActive(value: false);
		heroicWarpathNotification.SetActive(value: false);
	}

	private void InitializeLook()
	{
		InitializeLocked();
		InitializeHeroic();
		InitializeNotification();
	}

	private void InitializeLocked()
	{
		int warpathUnlockLevel = LevelManager.instance.warpathUnlockLevel;
		lockedTillLevel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), warpathUnlockLevel);
	}

	private void InitializeHeroic()
	{
		bool isHeroicMissionCompleted = MissionsManager.instance.isHeroicMissionCompleted;
		completedLabel.gameObject.SetActive(isHeroicMissionCompleted);
		getPart.gameObject.SetActive(!isHeroicMissionCompleted);
		if (GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
		{
			heroicPanel.alpha1 = ((!isHeroicMissionCompleted) ? 1f : mNotActiveAlpha);
		}
		if (getPart.activeSelf)
		{
			bool flag = MissionsManager.instance.heroicMission.heroicRewardGold > 0;
			float x = getLabel.relativeSize.x * getLabel.transform.localScale.x + 10f + 27f;
			goldSprite.gameObject.SetActive(flag);
			warbucksSprite.gameObject.SetActive(!flag);
			goldSprite.transform.localPosition = new Vector3(x, goldSprite.transform.localPosition.y, goldSprite.transform.localPosition.z);
			warbucksSprite.transform.localPosition = new Vector3(x, warbucksSprite.transform.localPosition.y, warbucksSprite.transform.localPosition.z);
		}
	}

	private void InitializeNotification()
	{
		bool active = Singleton<NotificationManager>.instance.NotificationWarpath();
		warpathNotification.SetActive(active);
		heroicWarpathNotification.SetActive(active);
	}

	private void InitializeHeroicLook()
	{
		if (!mInitialized)
		{
			mInitialized = true;
			getLabel.text = Localization.Localize("ID_GET");
			completedLabel.text = Localization.Localize("ID_COMPLETED");
			heroicMissionLabel.text = Localization.Localize("ID_HEROICMISSION");
			float num = 368f;
			float num2 = heroicMissionLabel.relativeSize.x * heroicMissionLabel.transform.localScale.x;
			float num3 = (num - num2) / 2f;
			float num4 = num3 - 20f;
			leftWing.transform.localScale = new Vector3(num4 + 8f, leftWing.transform.localScale.y, 1f);
			rightWing.transform.localScale = new Vector3(num4 + 8f, rightWing.transform.localScale.y, 1f);
			leftSkull.transform.localPosition = new Vector3(num4, leftSkull.transform.localPosition.y, leftSkull.transform.localPosition.z);
			rightSkull.transform.localPosition = new Vector3(num - num4, rightSkull.transform.localPosition.y, rightSkull.transform.localPosition.z);
		}
	}
}
