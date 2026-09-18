using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionScreen : GuiScreenSingle<MissionScreen>
{
	[Header("Chapters")]
	public List<UILabel> chapterNames;

	public List<UISprite> chapterBackgrounds;

	[Header("List of Records")]
	public MissionRecord missionPrefab;

	public UIDraggablePanel draggablePanel;

	public UIPooledGrid pooledGrid;

	[Header("Background")]
	public CameraPanelAligner aligner;

	public Transform bgScrollTransform;

	public float backgroundSpriteWidth = 2389f;

	public int missionsPerWorld = 15;

	public int maxWorld = 4;

	[Header("Heroic Mission")]
	public BoxCollider heroicButtonCollider;

	public UIPanel heroicButtonPanel;

	public UISprite heroicSinglePart;

	public GameObject heroicCoopPart;

	public UISprite heroicLockIcon;

	public GameObject heroicCompletedPart;

	public GameObject heroicRewardPart;

	public UILabel heroicDailyLabel;

	public WinStreakCounter heroicCountdown;

	public UILabel heroicRewardLabel;

	public GameObject heroicGetPart;

	public UISprite heroicGoldIcon;

	public UISprite heroicWarbucksIcon;

	public UILabel heroicRewardValue;

	[HideInInspector]
	public bool animateNewMissionOpened;

	[HideInInspector]
	public bool animateNewTypeCompletition;

	[HideInInspector]
	public int indexNewTypeCompletition;

	[HideInInspector]
	public bool isCoopNewTypeCompletition;

	[HideInInspector]
	public bool animateNewStarsCompletition;

	[HideInInspector]
	public int indexNewStarsCompletition;

	[HideInInspector]
	public int numberOfStarsOld;

	[HideInInspector]
	public int numberOfStarsNew;

	private bool mRepeatPlay;

	private int mActualMission;

	private int mLastMission = -1;

	private TweenAnimator mAnimator;

	private int mTweenToShowMissionDialog;

	private int mTweenAfterBgScale;

	private float mRecolorDuration = 0.25f;

	private MissionRecord mMissionChangeLockToUnlock;

	private bool mAnimationRunning;

	private ObjectPool mPool;

	public int numberOfMissions => Mathf.Min(missionsPerWorld * maxWorld, MissionsManager.instance.missions.Count);

	protected override void InitControls()
	{
		mRepeatPlay = false;
		animateNewMissionOpened = false;
		animateNewStarsCompletition = false;
		animateNewTypeCompletition = false;
		mAnimationRunning = false;
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mPool = Singleton<GuiManager>.instance.objectPool;
		UIEventListener uIEventListener = UIEventListener.Get(heroicButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HeroicButtonClick));
	}

	private void HeroicButtonClick(GameObject go)
	{
		Mission heroicMission = MissionsManager.instance.heroicMission;
		AlignToMission(heroicMission.index, instant: false);
		if (heroicMission.opened)
		{
			MissionsManager.instance.indexMissionToStart = heroicMission.index;
			Singleton<MapManager>.instance.SelectCurrentMap(heroicMission.map);
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<MissionDialog>.instance, 0f);
		}
		else
		{
			ConfirmDialog.ShowAlert(Localization.LocalizeFormat("ID_CONFIRM_MISSIONLOCKED", heroicMission.number), Localization.LocalizeFormat("ID_CONFIRM_MISSIONLOCKED_TEXT", heroicMission.number), 0f);
		}
	}

	private void OpenMission(GameObject go)
	{
		mAnimationRunning = false;
		UIDraggablePanel.panelDisabled = false;
		draggablePanel.onePanelDisabled = false;
		Mission mission = go.GetComponent<MissionRecord>().GetMission();
		if (mission == null)
		{
			Debug.LogError("No mission in button MISSION " + go.GetComponent<MissionRecord>().missionNumber);
		}
		else if (mission.opened || DebugSettings.debugEnabled)
		{
			Debug.LogFormat("Mission index: {0} , Mission completed: {1}, Mission opened: {2}. Open dialog.", mission.index, mission.completed, mission.opened);
			SoundsManager.Instance.PlayButtonClickedSound();
			MissionsManager.instance.indexMissionToStart = mission.index;
			Singleton<MapManager>.instance.SelectCurrentMap(mission.map);
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<MissionDialog>.instance, 0f);
		}
	}

	public void ReplayTweens()
	{
		mAnimator.FinishTweens();
		if (MissionsManager.instance.missions[0].completed)
		{
			animateNewMissionOpened = true;
		}
		InitGUIValues();
		mAnimator.PlayTweens();
	}

	public override void InitGUIValues()
	{
		base.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		if (!PlayerAnalytics.instance.data.warpathShown)
		{
			Singleton<BeanstalkServerManager>.instance.WarpathShown();
		}
		aligner.Align();
		SetUpChapterNames();
		mActualMission = GetOpenedMissionIndex();
		pooledGrid.MakeEmpty();
		pooledGrid.init(numberOfMissions, MissionInstantier, MissionFree, draggablePanel);
		AlignToMission((!mRepeatPlay) ? mActualMission : mLastMission);
		SetUpHeroicLook();
		if (animateNewMissionOpened)
		{
			Transform itemOnIndex = pooledGrid.GetItemOnIndex(mActualMission);
			MissionRecord missionRecord = ((!(itemOnIndex == null)) ? itemOnIndex.GetComponent<MissionRecord>() : null);
			if (missionRecord != null)
			{
				NewMissionOpenedAnimation(missionRecord);
			}
		}
		else
		{
			if (animateNewStarsCompletition)
			{
				NewStarsAnimation(indexNewStarsCompletition, numberOfStarsOld, numberOfStarsNew);
			}
			if (animateNewTypeCompletition)
			{
				NewTypeCompletitionAnimation(indexNewTypeCompletition, isCoopNewTypeCompletition);
			}
		}
		animateNewMissionOpened = false;
		animateNewTypeCompletition = false;
		animateNewStarsCompletition = false;
	}

	private int GetOpenedMissionIndex()
	{
		int num = numberOfMissions;
		int result = 0;
		for (int i = 0; i < num; i++)
		{
			if (MissionsManager.instance.missions[i].opened)
			{
				result = i;
			}
		}
		return result;
	}

	private void AlignToMission(int index, bool instant = true)
	{
		Vector3 positionForIndex = pooledGrid.getPositionForIndex(index);
		draggablePanel.AlignToCenter(positionForIndex + pooledGrid.transform.localPosition, instant);
		pooledGrid.PositionChanged();
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		bool flag = !MissionsManager.instance.isHeroicMissionCompleted;
		TweenAlpha.Begin(heroicButtonPanel.gameObject, fadeInTime, 0f, (!flag) ? 0.2f : 1f);
		StartCoroutine(Singleton<AtlasPreparer>.instance.LoadMissionMapsCoroutine());
	}

	private Transform MissionInstantier(int index)
	{
		if (index >= 0 && index < numberOfMissions)
		{
			MissionRecord missionRecord = mPool.InstantiateAsChild(missionPrefab, pooledGrid.gameObject, (index + 1).ToString("'Mission '0")) as MissionRecord;
			if (missionRecord != null)
			{
				missionRecord.missionNumber = index + 1;
				missionRecord.Init(MissionsManager.instance.missions[index]);
				if (index == mActualMission && !animateNewMissionOpened)
				{
					missionRecord.SetActual();
				}
				if (animateNewMissionOpened && index + 1 == mActualMission)
				{
					missionRecord.SetActual(overrideCompleted: true);
				}
				UIEventListener uIEventListener = UIEventListener.Get(missionRecord.gameObject);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OpenMission));
				return missionRecord.transform;
			}
		}
		return null;
	}

	private void MissionFree(Transform obj)
	{
		MissionRecord component = obj.GetComponent<MissionRecord>();
		if (component != null)
		{
			UIEventListener uIEventListener = UIEventListener.Get(component.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OpenMission));
			component.DestroyPooled();
		}
	}

	private void SetUpChapterNames()
	{
		for (int i = 0; i < chapterNames.Count; i++)
		{
			bool flag = i < maxWorld;
			chapterBackgrounds[i].transform.parent.gameObject.SetActive(flag);
			if (flag)
			{
				float val = chapterNames[i].relativeSize.x * chapterNames[i].transform.localScale.x + 70f;
				chapterBackgrounds[i].transform.localScale = chapterBackgrounds[i].transform.localScale.ReplaceX(val);
			}
		}
	}

	public void SetLastPlayedMission()
	{
		Mission currentMission = MissionsManager.instance.currentMission;
		mLastMission = currentMission.index;
		MissionsManager.instance.SetMissionDataBeforeStart(currentMission.index);
		mRepeatPlay = currentMission.completed;
		Debug.Log("SETTING last played mission\t\tRepeat: " + mRepeatPlay + "\t\tLast: " + mLastMission.ToString());
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		mAnimator.FinishTweens();
		Singleton<AtlasPreparer>.instance.UnloadMissionMaps();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		mAnimationRunning = false;
	}

	public override void DoBeforeShowUp()
	{
		UIDraggablePanel.panelDisabled = false;
		draggablePanel.onePanelDisabled = false;
		base.DoBeforeShowUp();
	}

	private void LateUpdate()
	{
		float x = draggablePanel.panel.cachedTransform.localPosition.x;
		if (x > 0f)
		{
			bgScrollTransform.localPosition = bgScrollTransform.localPosition.ReplaceX(0f);
			return;
		}
		float z = draggablePanel.panel.clipRange.z;
		float x2 = pooledGrid.transform.localPosition.x;
		float num = 0f - x;
		float num2 = num + z;
		float num3 = 0f;
		float num4 = 0f;
		for (int i = 0; i < maxWorld; i++)
		{
			int num5 = (i + 1) * missionsPerWorld;
			int index = num5 - 1;
			float x3 = pooledGrid.getPositionForIndex(index).x;
			float x4 = pooledGrid.getPositionForIndex(num5).x;
			num4 = x3 + (x4 - x3) * 0.6f + x2;
			if (i + 1 == maxWorld && num2 > num4)
			{
				num4 = num2;
			}
			if (num3 <= num && num2 <= num4)
			{
				float num6 = num4 - num2;
				float num7 = backgroundSpriteWidth - z;
				float num8 = num4 - num3;
				float num9 = num8 - z;
				float num10 = num6 * num7 / num9 - num7;
				bgScrollTransform.localPosition = bgScrollTransform.localPosition.ReplaceX(num10 - (float)i * backgroundSpriteWidth);
				break;
			}
			if (num < num3 && num3 <= num4)
			{
				bgScrollTransform.localPosition = bgScrollTransform.localPosition.ReplaceX(num3 - (float)i * backgroundSpriteWidth + x);
				break;
			}
			num3 = num4;
		}
	}

	private void SetUpHeroicLook()
	{
		bool isHeroicLocked = MissionsManager.instance.isHeroicLocked;
		heroicButtonCollider.gameObject.SetActive(!isHeroicLocked);
		if (isHeroicLocked)
		{
			return;
		}
		bool flag = MissionsManager.instance.heroicMission.heroicType == MissionsManager.HeroicType.Coop;
		bool opened = MissionsManager.instance.heroicMission.opened;
		bool isHeroicMissionCompleted = MissionsManager.instance.isHeroicMissionCompleted;
		heroicSinglePart.gameObject.SetActive(!flag);
		heroicCoopPart.SetActive(flag);
		heroicLockIcon.gameObject.SetActive(!opened);
		HeroicButton(opened && !isHeroicMissionCompleted, !isHeroicMissionCompleted);
		heroicCompletedPart.gameObject.SetActive(isHeroicMissionCompleted);
		heroicRewardPart.gameObject.SetActive(!isHeroicMissionCompleted);
		if (!isHeroicMissionCompleted)
		{
			bool flag2 = MissionsManager.instance.heroicMission.heroicRewardGold > 0;
			int num = MissionsManager.instance.heroicMission.heroicRewardWB + MissionsManager.instance.heroicMission.heroicRewardGold;
			int midnight = Singleton<BeanstalkServerManager>.instance.midnight;
			bool flag3 = midnight < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			InitializeRewardPart();
			heroicGoldIcon.gameObject.SetActive(flag2);
			heroicWarbucksIcon.gameObject.SetActive(!flag2);
			heroicRewardValue.text = MiscTools.FormatBigNumber(num);
			if (flag3)
			{
				heroicCountdown.StopCountingTo();
				WinStreakCounter winStreakCounter = heroicCountdown;
				winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(CountDownEnd));
				heroicCountdown.counterLabel.text = string.Empty;
			}
			else
			{
				heroicCountdown.StartCountingTo(midnight);
				WinStreakCounter winStreakCounter2 = heroicCountdown;
				winStreakCounter2.winStreakTimer = (Action)Delegate.Remove(winStreakCounter2.winStreakTimer, new Action(CountDownEnd));
				WinStreakCounter winStreakCounter3 = heroicCountdown;
				winStreakCounter3.winStreakTimer = (Action)Delegate.Combine(winStreakCounter3.winStreakTimer, new Action(CountDownEnd));
			}
		}
		else
		{
			heroicCountdown.StopCountingTo();
			WinStreakCounter winStreakCounter4 = heroicCountdown;
			winStreakCounter4.winStreakTimer = (Action)Delegate.Remove(winStreakCounter4.winStreakTimer, new Action(CountDownEnd));
			heroicCountdown.counterLabel.text = string.Empty;
		}
	}

	private void HeroicButton(bool setActive, bool fullAlpha)
	{
		if (GuiScreenSingle<MissionScreen>.instance.isFullyShowed)
		{
			heroicButtonPanel.alpha1 = ((!fullAlpha) ? 0.2f : 1f);
		}
	}

	private void InitializeRewardPart()
	{
		heroicDailyLabel.text = Localization.LocalizeFormat("ID_DAILYHEROICMISSIONMINUS", MissionsManager.instance.heroicMission.number);
		heroicRewardLabel.text = Localization.Localize("ID_REWARD");
		float val = heroicDailyLabel.relativeSize.x * heroicDailyLabel.transform.localScale.x + 10f;
		heroicCountdown.transform.localPosition = heroicCountdown.transform.localPosition.ReplaceX(val);
		val = heroicRewardLabel.relativeSize.x * heroicRewardLabel.transform.localScale.x + 20f + 28f;
		heroicGetPart.transform.localPosition = heroicGetPart.transform.localPosition.ReplaceX(val);
	}

	private void CountDownEnd()
	{
		InitGUIValues();
	}

	private void NewMissionOpenedAnimation(MissionRecord actual)
	{
		if (actual == null)
		{
			return;
		}
		MissionRecord missionRecord = null;
		Transform itemOnIndex = pooledGrid.GetItemOnIndex(actual.missionNumber - 2);
		if (itemOnIndex != null)
		{
			missionRecord = itemOnIndex.GetComponent<MissionRecord>();
		}
		mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		if (missionRecord == null)
		{
			Debug.LogError("ANIMATION MISSION SCREEN - do not know (NULL) last completed mission record");
			return;
		}
		int idToContinue = -1;
		float dur = 0.5f;
		idToContinue = AddAnimationForStarsAndInitialize(missionRecord, 0, missionRecord.GetMission().numberOfStars, dur, 0.7f, idToContinue);
		idToContinue = AddAnimationsForCoopOrSingleAndInitialize(missionRecord, missionRecord.GetMission().completedInCoop, dur, 0.7f, -1);
		idToContinue = AddAnimationForRecolor(missionRecord, mRecolorDuration, idToContinue);
		if (actual != missionRecord)
		{
			AddAnimationForChangeFromLockToActual(actual, dur, idToContinue);
		}
		mAnimator.GenerateTweens();
		TweenAnimator tweenAnimator = mAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(OnTweenFinished));
		mAnimator.PlayTweens();
		mAnimationRunning = true;
		UIDraggablePanel.panelDisabled = true;
		draggablePanel.onePanelDisabled = true;
		Debug.Log("!!! ANIMATION from \"MISSION " + missionRecord.missionNumber + "\" to \"MISSION " + actual.missionNumber + "\"");
	}

	private void NewTypeCompletitionAnimation(int index, bool isCoop)
	{
		MissionRecord missionRecord = null;
		float dur = 0.5f;
		Transform itemOnIndex = pooledGrid.GetItemOnIndex(index);
		if (itemOnIndex != null)
		{
			missionRecord = itemOnIndex.GetComponent<MissionRecord>();
		}
		if (!animateNewStarsCompletition)
		{
			mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		}
		if (!(missionRecord == null))
		{
			AddAnimationsForCoopOrSingleAndInitialize(missionRecord, isCoop, dur, 0.7f, -1);
			mAnimator.GenerateTweens();
			mAnimator.PlayTweens();
			mAnimationRunning = true;
			Debug.Log("!!! ANIMATION \"MISSION " + missionRecord.missionNumber + "\" was completed in " + ((!isCoop) ? "SINGLE" : "COOP") + " mode for first time");
		}
	}

	private void NewStarsAnimation(int index, int fromStars, int toStars)
	{
		MissionRecord missionRecord = null;
		float dur = 0.5f;
		Transform itemOnIndex = pooledGrid.GetItemOnIndex(index);
		if (itemOnIndex != null)
		{
			missionRecord = itemOnIndex.GetComponent<MissionRecord>();
		}
		mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		if (!(missionRecord == null))
		{
			int idToContinue = AddAnimationForStarsAndInitialize(missionRecord, fromStars, toStars, dur, 0.7f, -1);
			idToContinue = AddAnimationForRecolor(missionRecord, mRecolorDuration, idToContinue);
			mAnimator.GenerateTweens();
			mAnimator.PlayTweens();
			mAnimationRunning = true;
			Debug.Log("!!! ANIMATION \"MISSION " + missionRecord.missionNumber + "\" gain stars FROM " + fromStars + " TO " + toStars);
		}
	}

	private int AddAnimationsForCoopOrSingleAndInitialize(MissionRecord missionToAnimate, bool isCoop, float dur, float del, int idToContinue)
	{
		GameObject gameObject = ((!isCoop) ? missionToAnimate.completedAlone : missionToAnimate.completedInCoop);
		gameObject.SetActive(value: true);
		int num = idToContinue + 1;
		bool flag = false;
		UILabel componentInChildren = gameObject.GetComponentInChildren<UILabel>();
		if (componentInChildren != null)
		{
			componentInChildren.alpha = 0f;
		}
		UISprite[] componentsInChildren = gameObject.GetComponentsInChildren<UISprite>();
		foreach (UISprite uISprite in componentsInChildren)
		{
			uISprite.alpha = 0f;
		}
		UISprite[] componentsInChildren2 = gameObject.GetComponentsInChildren<UISprite>();
		foreach (UISprite uISprite2 in componentsInChildren2)
		{
			mAnimator.AddTween(num++, TweenAnimator.TweenType.Alpha, uISprite2.gameObject, dur, 1f, del, idToContinue);
			Vector3 localScale = uISprite2.transform.localScale;
			Vector3 vector = localScale.MultiplyXY(5f);
			TweenAnimator tweenAnimator = mAnimator;
			object obj = vector;
			tweenAnimator.AddTween(num++, TweenAnimator.TweenType.Scale, uISprite2.gameObject, dur, localScale, del, idToContinue, obj);
			flag = true;
		}
		if (componentInChildren != null)
		{
			mAnimator.AddTween(playAfterIdFinished: num - 1, id: num, tweenType: TweenAnimator.TweenType.Alpha, tweenTarget: componentInChildren.gameObject, time: dur, to: 1f, delay: 0f);
			flag = true;
		}
		return (!flag) ? idToContinue : num;
	}

	private int AddAnimationForStarsAndInitialize(MissionRecord missionToAnimate, int fromStars, int toStars, float dur, float del, int idToContinue)
	{
		int num = idToContinue + 1;
		fromStars++;
		for (int i = fromStars; i <= toStars; i++)
		{
			UISprite uISprite = missionToAnimate.star1Sprite;
			switch (i)
			{
			case 2:
				uISprite = missionToAnimate.star2Sprite;
				break;
			case 3:
				uISprite = missionToAnimate.star3Sprite;
				break;
			}
			uISprite.alpha = 0f;
		}
		for (int j = fromStars; j <= toStars; j++)
		{
			UISprite uISprite2 = missionToAnimate.star1Sprite;
			switch (j)
			{
			case 2:
				uISprite2 = missionToAnimate.star2Sprite;
				del += 0.3f;
				break;
			case 3:
				uISprite2 = missionToAnimate.star3Sprite;
				del += 0.3f;
				break;
			}
			uISprite2.MakePixelPerfect();
			mAnimator.AddTween(num++, TweenAnimator.TweenType.Alpha, uISprite2.gameObject, dur, 1f, del, idToContinue, 0f);
			mAnimator.AddSoundTween(num++, SoundsManager.SoundsEnum.StarGained, 0f, idToContinue);
			Vector3 localScale = uISprite2.transform.localScale;
			Vector3 vector = localScale.MultiplyXY(5f);
			TweenAnimator tweenAnimator = mAnimator;
			object obj = vector;
			tweenAnimator.AddTween(num++, TweenAnimator.TweenType.Scale, uISprite2.gameObject, dur, localScale, del, idToContinue, obj);
		}
		return num - 1;
	}

	private int AddAnimationForRecolor(MissionRecord missionToAnimate, float dur, int idToContinue)
	{
		int num = idToContinue + 1;
		int playAfterIdFinished;
		if (missionToAnimate.GetMission() != null && missionToAnimate.GetMission().numberOfStars == 3)
		{
			TweenAnimator tweenAnimator = mAnimator;
			playAfterIdFinished = idToContinue;
			tweenAnimator.AddTween(num++, TweenAnimator.TweenType.Color, missionToAnimate.labelBg.gameObject, dur, Colours.orange, 0f, playAfterIdFinished);
			TweenAnimator tweenAnimator2 = mAnimator;
			playAfterIdFinished = idToContinue;
			tweenAnimator2.AddTween(num++, TweenAnimator.TweenType.Color, missionToAnimate.missionLabel.gameObject, dur, Color.white, 0f, playAfterIdFinished);
		}
		else
		{
			TweenAnimator tweenAnimator3 = mAnimator;
			playAfterIdFinished = idToContinue;
			tweenAnimator3.AddTween(num++, TweenAnimator.TweenType.Color, missionToAnimate.labelBg.gameObject, dur, Color.white, 0f, playAfterIdFinished);
			TweenAnimator tweenAnimator4 = mAnimator;
			playAfterIdFinished = idToContinue;
			tweenAnimator4.AddTween(num++, TweenAnimator.TweenType.Color, missionToAnimate.missionLabel.gameObject, dur, Color.black, 0f, playAfterIdFinished);
		}
		TweenAnimator tweenAnimator5 = mAnimator;
		playAfterIdFinished = idToContinue;
		tweenAnimator5.AddTween(num++, TweenAnimator.TweenType.Color, missionToAnimate.shadowBg.gameObject, dur, Colours.blackShadow, 0f, playAfterIdFinished);
		return num - 1;
	}

	private void AddAnimationForChangeFromLockToActual(MissionRecord missionToAnimate, float dur, int idToContinue)
	{
		int num = idToContinue + 1;
		missionToAnimate.lockedGraphics.SetActive(value: true);
		missionToAnimate.unlockedGraphics.SetActive(value: true);
		mMissionChangeLockToUnlock = missionToAnimate;
		missionToAnimate.labelBg.color = Color.black;
		missionToAnimate.missionLabel.color = Color.white;
		missionToAnimate.shadowBg.transform.localScale = MissionRecord.lockedScale;
		missionToAnimate.shadowBg.transform.localPosition = MissionRecord.lockedBgPos;
		missionToAnimate.shadowBg.color = Colours.blueShadow;
		missionToAnimate.shadowBg.alpha = 0f;
		missionToAnimate.lockedBackground.color = Colours.blackShadow;
		foreach (UISprite starShadow in missionToAnimate.starShadows)
		{
			starShadow.alpha = 0f;
		}
		UISprite lockIcon = missionToAnimate.lockIcon;
		UISprite lockedBackground = missionToAnimate.lockedBackground;
		UISprite shadowBg = missionToAnimate.shadowBg;
		mAnimator.AddTween(from: MissionRecord.lockIconScale, id: num++, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: lockIcon.gameObject, time: dur, to: MissionRecord.lockIconScale.MultiplyXY(5f), delay: 0f, playAfterIdFinished: idToContinue);
		mAnimator.AddTween(num++, TweenAnimator.TweenType.Alpha, lockIcon.gameObject, dur, 0f, 0f, idToContinue, 1f);
		TweenAnimator tweenAnimator = mAnimator;
		int playAfterIdFinished = idToContinue;
		tweenAnimator.AddTween(num++, TweenAnimator.TweenType.Color, missionToAnimate.labelBg.gameObject, mRecolorDuration, Colours.blueMission, 0f, playAfterIdFinished);
		TweenAnimator tweenAnimator2 = mAnimator;
		playAfterIdFinished = idToContinue;
		tweenAnimator2.AddTween(num++, TweenAnimator.TweenType.Color, missionToAnimate.missionLabel.gameObject, mRecolorDuration, Color.white, 0f, playAfterIdFinished);
		TweenAnimator tweenAnimator3 = mAnimator;
		playAfterIdFinished = idToContinue;
		tweenAnimator3.AddTween(num++, TweenAnimator.TweenType.Alpha, missionToAnimate.shadowBg.gameObject, mRecolorDuration, 0.5f, 0f, playAfterIdFinished);
		TweenAnimator tweenAnimator4 = mAnimator;
		playAfterIdFinished = idToContinue;
		tweenAnimator4.AddTween(num++, TweenAnimator.TweenType.Alpha, missionToAnimate.lockedBackground.gameObject, mRecolorDuration, 0f, 0f, playAfterIdFinished);
		mAnimator.AddTween(from: MissionRecord.lockedScale, id: num++, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: lockedBackground.gameObject, time: dur, to: MissionRecord.unlockedScale, delay: 0f, playAfterIdFinished: idToContinue);
		mAnimator.AddTween(from: MissionRecord.lockedBgPos, id: num++, tweenType: TweenAnimator.TweenType.Position, tweenTarget: lockedBackground.gameObject, time: dur, to: MissionRecord.unlockedBgPos, delay: 0f, playAfterIdFinished: idToContinue);
		mAnimator.AddTween(from: MissionRecord.lockedScale, id: num++, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: shadowBg.gameObject, time: dur, to: MissionRecord.unlockedScale, delay: 0f, playAfterIdFinished: idToContinue);
		mAnimator.AddTween(from: MissionRecord.lockedBgPos, id: num++, tweenType: TweenAnimator.TweenType.Position, tweenTarget: shadowBg.gameObject, time: dur, to: MissionRecord.unlockedBgPos, delay: 0f, playAfterIdFinished: idToContinue);
		mTweenAfterBgScale = num - 1;
		foreach (UISprite starShadow2 in missionToAnimate.starShadows)
		{
			starShadow2.alpha = 0f;
			Vector3 vector = starShadow2.transform.localPosition.ReplaceY(0f);
			Vector3 vector2 = vector.ReplaceY(10f);
			Vector3 vector3 = vector.ReplaceY(-30f);
			TweenAnimator tweenAnimator5 = mAnimator;
			object obj = vector3;
			tweenAnimator5.AddTween(num, TweenAnimator.TweenType.Position, starShadow2.gameObject, dur, vector2, 0f, num - 2, obj);
			mAnimator.AddTween(num + 1, TweenAnimator.TweenType.Alpha, starShadow2.gameObject, 0.3f, 1f, 0f, num - 2, 0f);
			TweenAnimator tweenAnimator6 = mAnimator;
			playAfterIdFinished = num;
			tweenAnimator6.AddTween(num + 2, TweenAnimator.TweenType.Position, starShadow2.gameObject, dur, vector, 0f, playAfterIdFinished);
			num += 3;
		}
		mTweenToShowMissionDialog = num - 1;
	}

	private void OnTweenFinished(int tweenId)
	{
		if (tweenId == mTweenAfterBgScale)
		{
			mMissionChangeLockToUnlock.lockedGraphics.SetActive(value: false);
			mMissionChangeLockToUnlock.lockIcon.alpha = 1f;
			mMissionChangeLockToUnlock.lockIcon.transform.localScale = MissionRecord.lockIconScale;
			mMissionChangeLockToUnlock.lockedBackground.color = Colours.blackShadow;
			mMissionChangeLockToUnlock.lockedBackground.transform.localScale = MissionRecord.lockedScale;
			mMissionChangeLockToUnlock.lockedBackground.transform.localPosition = MissionRecord.lockedBgPos;
		}
		if (tweenId == mTweenToShowMissionDialog && mAnimationRunning)
		{
			UIDraggablePanel.panelDisabled = false;
			draggablePanel.onePanelDisabled = false;
			if (!DialogManager.instance.isSomeDialogShowed)
			{
				OpenMission(mMissionChangeLockToUnlock.gameObject);
			}
		}
	}
}
