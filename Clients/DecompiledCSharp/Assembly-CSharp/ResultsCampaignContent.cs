using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsCampaignContent : Core_BaseScript
{
	[Header("Experience")]
	public UISprite experienceXPBackground;

	public UILabel experienceXPLabel;

	public UISprite experienceBorder;

	public UISprite experienceProgressBg;

	public UISprite experienceProgressFg;

	public UILabel experienceNumber;

	public UILabel experienceBonusName;

	public UILabel experienceBonusNumber;

	[Header("Mission")]
	public UISprite missionBackground;

	public UISprite missionFlash;

	public GameObject missionObjectiveParent;

	public UILabel missionObjective;

	[Header("-Header")]
	public GameObject missionHeader;

	public UISprite missionHeaderBackground;

	public UILabel missionHeaderName;

	[Header("-Stars")]
	public UISprite star1;

	public UISprite star2;

	public UISprite star3;

	public UISprite starBackground1;

	public UISprite starBackground2;

	public UISprite starBackground3;

	[Header("-Alone VS Coop")]
	public GameObject missionAlone;

	public GameObject missionCoop;

	[Header("Tutorial")]
	public UISprite tutorialBackground;

	public UISprite tutorialFlash;

	public UILabel tutorialObjective;

	[Header("-Header")]
	public GameObject tutorialHeader;

	public UISprite tutorialHeaderBackground;

	public UILabel tutorialHeaderName;

	[Header("Heroic")]
	public UISprite heroicBackground;

	public UISprite heroicFlash;

	public GameObject heroicObjectiveParent;

	public UILabel heroicObjective;

	[Header("-Header")]
	public GameObject heroicHeader;

	public UISprite heroicHeaderBackground;

	public UILabel heroicHeaderName;

	[Header("-Middle")]
	public GameObject heroicMiddle;

	public UISprite heroicLeftCorner;

	public UISprite heroicRightCorner;

	public UISprite heroicMiddleBackground;

	public UISprite heroicSingleSkull;

	public UISprite heroicCoopSkull1;

	public UISprite heroicCoopSkull2;

	[Header("-Status")]
	public UISprite heroicCompletedCheck;

	public UILabel heroicStatus;

	[Header("VIP")]
	public GameObject vipHeader;

	public UISprite vipLeftWing;

	public UISprite vipRightWing;

	public UISprite vipBackground;

	public UILabel vipEarning;

	public UISprite vipBorder;

	public UISprite vipShadowBorder;

	[Header("Battle Rewards")]
	public ResultsRewards battleRewards;

	[Header("Become VIP")]
	public GameObject becomeVIP;

	public UILabel becomeVIPLabel;

	[Header("Replay")]
	public UIButton saveReplay;

	public BoxCollider saveReplayCollider;

	public UILabel saveReplayLabel;

	public UISprite saveReplayBackground;

	private List<TweenAnimator> mAnimator = new List<TweenAnimator>();

	private MenuHeader mHeader;

	private bool mIsLvlUp;

	private Vector3 mSmallStarScale = new Vector3(96f, 94f, 1f);

	private IntObject mTotalXp = new IntObject(0);

	private IntObject mWinXp = new IntObject(0);

	private IntObject mTimeXp = new IntObject(0);

	private IntObject mBattleXp = new IntObject(0);

	private FloatObject mProgress = new FloatObject(0f);

	private TweenAnimator mAnimatorMission;

	private TweenAnimator mAnimatorTutorial;

	private TweenAnimator mAnimatorHeroicSingleWin;

	private TweenAnimator mAnimatorHeroicSingleLoose;

	private TweenAnimator mAnimatorHeroicCoopWin;

	private TweenAnimator mAnimatorHeroicCoopLoose;

	private IntObject mCardsGot = new IntObject(0);

	public int cardsGot
	{
		set
		{
			mCardsGot.val = value;
		}
	}

	public bool showLevelUp
	{
		get
		{
			return mIsLvlUp;
		}
		set
		{
			mIsLvlUp = value;
		}
	}

	public void InitControls()
	{
		mSmallStarScale = star1.transform.localScale;
		mHeader = GuiElementSingle<MenuHeader>.instance;
		mAnimator.Add(CreateAnimatorForExperience(experienceXPBackground, experienceXPLabel, experienceBorder, experienceProgressFg, experienceProgressBg, experienceNumber, ref mTotalXp, ref mProgress));
		mAnimatorMission = CreateAnimatorForMission();
		mAnimatorTutorial = CreateAnimatorForTutorial();
		mAnimatorHeroicSingleWin = CreateAnimatorForHeroic(isCoop: false, isCompleted: true);
		mAnimatorHeroicSingleLoose = CreateAnimatorForHeroic(isCoop: false, isCompleted: false);
		mAnimatorHeroicCoopWin = CreateAnimatorForHeroic(isCoop: true, isCompleted: true);
		mAnimatorHeroicCoopLoose = CreateAnimatorForHeroic(isCoop: true, isCompleted: false);
		mAnimator.Add(mAnimatorMission);
		mAnimator.Add(CreateAnimatorForVIP(vipHeader, vipLeftWing, vipRightWing, vipBackground, vipEarning, vipBorder, vipShadowBorder));
		mAnimator.Add(battleRewards.InitControls());
		mAnimator.Add(CreateAnimatorForCards());
		UIEventListener.Get(saveReplay.gameObject).onClick = delegate
		{
			Singleton<Recording>.instance.ShowPreview();
			InvokeAfterRealTime(delegate
			{
				saveReplay.gameObject.SetActive(value: false);
			}, 0.5f);
		};
		UIEventListener.Get(becomeVIP).onClick = delegate
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		};
		float num = saveReplayLabel.relativeSize.x * saveReplayLabel.transform.localScale.x;
		float num2 = num + 60f;
		saveReplayBackground.transform.localScale = saveReplayBackground.transform.localScale.ReplaceX(num2);
		saveReplayCollider.center = saveReplayCollider.center.ReplaceX(num2 / 2f);
		saveReplayCollider.size = saveReplayCollider.size.ReplaceX(num2 + 20f);
		becomeVIPLabel.text = Localization.Localize("ID_BECOMEVIP");
		MiscTools.SetUILabelRescale(becomeVIPLabel, 30f, 20f, 200);
		TweenScale tweenScale = TweenScale.Begin(becomeVIPLabel.gameObject, 0.4f, becomeVIPLabel.transform.localScale, becomeVIPLabel.transform.localScale.MultiplyXY(1.1f));
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 0;
	}

	private TweenAnimator CreateAnimatorForExperience(UISprite xpBackground, UILabel xpLabel, UISprite border, UISprite progressFg, UISprite progressBg, UILabel number, ref IntObject totalXp, ref FloatObject fillInto)
	{
		float dur = 0.4f;
		TweenAnimator tweenAnimator = number.transform.parent.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		tweenAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, xpBackground.gameObject, dur, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(2, TweenAnimator.TweenType.Alpha, xpLabel.gameObject, dur, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(3, TweenAnimator.TweenType.Alpha, border.gameObject, dur, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(4, TweenAnimator.TweenType.Alpha, progressFg.gameObject, dur, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(5, TweenAnimator.TweenType.Alpha, progressBg.gameObject, dur, 0.4f, 0f, -1, 0f);
		tweenAnimator.AddTween(6, TweenAnimator.TweenType.Alpha, number.gameObject, dur, 1f, 0f, -1, 0f);
		dur = 0.5f;
		tweenAnimator.AddTween(8, TweenAnimator.TweenType.TextCounter, number.gameObject, dur + 0.8f, totalXp, 0f, 6);
		tweenAnimator.AddTween(9, TweenAnimator.TweenType.ProgressBar, progressBg.gameObject, dur, fillInto, 0f, 6);
		tweenAnimator.AddTween(10, TweenAnimator.TweenType.ProgressBar, progressFg.gameObject, 0.8f, fillInto, 0f, 9);
		tweenAnimator.AddTween(11, TweenAnimator.TweenType.ProgressBar, mHeader.progressSpriteWhite.gameObject, dur, fillInto, 0f, 6);
		tweenAnimator.AddTween(12, TweenAnimator.TweenType.ProgressBar, mHeader.progressSprite.gameObject, 0.8f, fillInto, 0f, 11);
		tweenAnimator.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 6)
			{
				ShowingBonuses(dur / 2f);
			}
			if (mIsLvlUp && tweenId == 12)
			{
				StartCoroutine(LvLUpCoroutine());
			}
		};
		return tweenAnimator;
	}

	private void ShowingBonuses(float dur)
	{
		float num = 0f;
		if (mWinXp.val > 0)
		{
			ShowBonus(Localization.Localize("ID_GUI_WINXPBONUS"), ref mWinXp, dur);
			num += 4f * dur + 0.8f;
		}
		if (mTimeXp.val > 0)
		{
			InvokeAfter(delegate
			{
				ShowBonus(Localization.Localize("ID_GUI_TIMEXPBONUS"), ref mTimeXp, dur);
			}, num);
			num += 4f * dur + 0.8f;
		}
		InvokeAfter(delegate
		{
			ShowBonus(Localization.Localize("ID_GUI_BATTLEXPGAIN"), ref mBattleXp, dur);
		}, num);
	}

	private void ShowBonus(string bonusName, ref IntObject bonusXP, float dur)
	{
		experienceBonusName.text = bonusName;
		experienceBonusNumber.text = "+0";
		IntObject intObject = new IntObject(bonusXP.val);
		TweenAlpha.Begin(experienceBonusName.gameObject, dur, 0f, 1f);
		TweenPosition.Begin(experienceBonusName.gameObject, dur, new Vector3(74f, 98f, -1f), new Vector3(74f, 146f, -1f)).onFinished = delegate
		{
			TweenPosition.Begin(experienceBonusName.gameObject, dur, new Vector3(74f, 126f, -1f));
			TweenAlpha.Begin(experienceBonusNumber.gameObject, dur, 0f, 1f);
			TweenPosition.Begin(experienceBonusNumber.gameObject, dur, new Vector3(86f, 126f, -1f), new Vector3(132f, 126f, -1f)).onFinished = delegate
			{
				TweenTextCounter.Begin(experienceBonusNumber.gameObject, 0.8f, intObject).onFinished = delegate
				{
					TweenPosition.Begin(experienceBonusName.gameObject, dur, new Vector3(74f, 126f, -1f)).onFinished = delegate
					{
						TweenAlpha.Begin(experienceBonusName.gameObject, dur, 0f);
						TweenPosition.Begin(experienceBonusName.gameObject, dur, new Vector3(74f, 98f, -1f));
						TweenAlpha.Begin(experienceBonusNumber.gameObject, dur, 0f);
					};
				};
			};
		};
	}

	private IEnumerator LvLUpCoroutine()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 0f);
		yield return new WaitForSeconds(0.5f);
		while (GuiElementSingle<LevelUpDialog>.instance.isShowed)
		{
			yield return null;
		}
		mIsLvlUp = false;
		TweenAlpha tw = TweenAlpha.Begin(mHeader.progressSprite.gameObject, 0.2f, 0f, 1f);
		tw.style = UITweener.Style.PingPong;
		tw.NumOfRepetitions = 11;
		tw.onFinished = delegate
		{
			float duration = 0.4f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1f)
			{
				num -= 1f;
			}
			mProgress.val = num;
			mHeader.UpdateLevel();
			TweenProgressBar.Begin(mHeader.progressSpriteWhite.gameObject, duration, new FloatObject(0f), mProgress);
			TweenProgressBar.Begin(mHeader.progressSprite.gameObject, duration, new FloatObject(0f), mProgress);
			TweenProgressBar.Begin(experienceProgressBg.gameObject, duration, new FloatObject(0f), mProgress);
			TweenProgressBar.Begin(experienceProgressFg.gameObject, duration, new FloatObject(0f), mProgress);
		};
		PlayAnimationsAfterLevelUp();
	}

	private void AddInitialShowingAnimationToAnimator(ref TweenAnimator anim, GameObject header, UISprite headerBackground, UILabel headerLabel, UISprite background, UISprite flash)
	{
		float num = 0.4f;
		Vector3 localPosition = background.transform.localPosition;
		anim.AddTween(1, TweenAnimator.TweenType.Alpha, background.gameObject, num, 1f, 0f, -1, 0f);
		anim.AddTween(from: localPosition + new Vector3(0f, -16f, 0f), id: 2, tweenType: TweenAnimator.TweenType.Position, tweenTarget: background.gameObject, time: num, to: localPosition, delay: 0f);
		localPosition = header.transform.localPosition;
		anim.AddTween(3, TweenAnimator.TweenType.Alpha, headerBackground.gameObject, num, 1f, 0f, -1, 0f);
		anim.AddTween(4, TweenAnimator.TweenType.Alpha, headerLabel.gameObject, num, 1f, 0f, -1, 0f);
		TweenAnimator obj = anim;
		object obj2 = localPosition + new Vector3(0f, 24f, 0f);
		obj.AddTween(5, TweenAnimator.TweenType.Position, header, num, localPosition, 0f, -1, obj2);
		num /= 7f;
		anim.AddTween(6, TweenAnimator.TweenType.Alpha, flash.gameObject, num, 0f, 0f, 5, 0f);
		anim.AddTween(7, TweenAnimator.TweenType.Alpha, flash.gameObject, num, 0.4f, 0f, 6, 0f, UITweener.Method.EaseInOut, UITweener.Style.PingPong, 5);
		anim.AddTween(8, TweenAnimator.TweenType.Alpha, flash.gameObject, num, 0f, 0f, 7);
	}

	private TweenAnimator CreateAnimatorForMission()
	{
		float dur = 0.4f;
		TweenAnimator anim = missionBackground.transform.parent.gameObject.AddComponent<TweenAnimator>();
		anim.allTweens = new List<TweenAnimator.TweenRecord>();
		AddInitialShowingAnimationToAnimator(ref anim, missionHeader, missionHeaderBackground, missionHeaderName, missionBackground, missionFlash);
		anim.AddTween(9, TweenAnimator.TweenType.Alpha, starBackground1.gameObject, dur, 1f, 0f, 5);
		anim.AddTween(10, TweenAnimator.TweenType.Alpha, starBackground2.gameObject, dur, 1f, 0f, 5);
		anim.AddTween(11, TweenAnimator.TweenType.Alpha, starBackground3.gameObject, dur, 1f, 0f, 5);
		Vector3 one = Vector3.one;
		Vector3 vector = new Vector3(1.25f, 1.25f, 1f);
		Vector3 vector2 = new Vector3(0.9f, 0.9f, 1f);
		anim.AddTween(12, TweenAnimator.TweenType.Alpha, missionObjectiveParent, dur, 1f, dur * 2f / 3f, -1, 0f);
		TweenAnimator tweenAnimator = anim;
		object obj = vector;
		tweenAnimator.AddTween(13, TweenAnimator.TweenType.Scale, missionObjectiveParent, dur, vector2, dur * 2f / 3f, -1, obj);
		anim.AddTween(14, TweenAnimator.TweenType.Scale, missionObjectiveParent, dur, one, 0f, 13);
		anim.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 5)
			{
				AnimateAloneOrCoopObject(0.2f);
				ShowGainedStarsPreviousGames(dur);
			}
			if (tweenId == 6)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
			}
			if (tweenId == 11)
			{
				ShowNewStarsGained(0.3f);
			}
		};
		return anim;
	}

	private void AnimateAloneOrCoopObject(float dur)
	{
		bool flag = Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot;
		missionAlone.SetActive(!flag);
		missionCoop.SetActive(flag);
		GameObject icon = ((!flag) ? missionAlone : missionCoop);
		Vector3 position = icon.transform.localPosition;
		position.y = 92f;
		TweenPosition.Begin(icon, dur, position + new Vector3(0f, -20f, 0f), position + new Vector3(0f, 10f, 0f)).onFinished = delegate
		{
			TweenPosition.Begin(icon, dur, position).onFinished = null;
		};
	}

	private void ShowGainedStarsPreviousGames(float dur)
	{
		int num = MissionsManager.instance.LastStars();
		if (num >= 1)
		{
			TweenAlpha.Begin(star1.gameObject, dur, 0f, 1f).delay = 0f;
		}
		if (num >= 2)
		{
			TweenAlpha.Begin(star2.gameObject, dur, 0f, 1f).delay = 0f;
		}
		if (num >= 3)
		{
			TweenAlpha.Begin(star3.gameObject, dur, 0f, 1f).delay = 0f;
		}
	}

	private void ShowNewStarsGained(float dur)
	{
		int num = MissionsManager.instance.LastStars();
		int num2 = ((Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.MissionSuccess) ? MissionsManager.instance.currentMission.numberOfStars : 0);
		if (num < 1 && num2 >= 1)
		{
			float delay = 0f;
			PlayStarSound(delay);
			TweenAlpha.Begin(star1.gameObject, dur - 0.1f, 0f, 1f).delay = delay;
			TweenScale.Begin(star1.gameObject, dur, new Vector3(mSmallStarScale.x * 5f, mSmallStarScale.y * 5f, 1f), mSmallStarScale).delay = delay;
		}
		if (num < 2 && num2 >= 2)
		{
			float delay2 = dur / 2f;
			PlayStarSound(delay2);
			TweenAlpha.Begin(star2.gameObject, dur - 0.1f, 0f, 1f).delay = delay2;
			TweenScale.Begin(star2.gameObject, dur, new Vector3(mSmallStarScale.x * 5f, mSmallStarScale.y * 5f, 1f), mSmallStarScale).delay = delay2;
		}
		if (num < 3 && num2 >= 3)
		{
			PlayStarSound(dur);
			TweenAlpha.Begin(star3.gameObject, dur - 0.1f, 0f, 1f).delay = dur;
			TweenScale.Begin(star3.gameObject, dur, new Vector3(mSmallStarScale.x * 5f, mSmallStarScale.y * 5f, 1f), mSmallStarScale).delay = dur;
		}
	}

	private void PlayStarSound(float delay)
	{
		if (delay <= 0f)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.StarGained);
			return;
		}
		InvokeAfter(delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.StarGained);
		}, delay);
	}

	private TweenAnimator CreateAnimatorForTutorial()
	{
		float num = 0.4f;
		TweenAnimator anim = tutorialBackground.transform.parent.gameObject.AddComponent<TweenAnimator>();
		anim.allTweens = new List<TweenAnimator.TweenRecord>();
		AddInitialShowingAnimationToAnimator(ref anim, tutorialHeader, tutorialHeaderBackground, tutorialHeaderName, tutorialBackground, tutorialFlash);
		Vector3 localScale = tutorialObjective.transform.localScale;
		Vector3 vector = localScale * 1.25f;
		vector.z = 1f;
		Vector3 vector2 = localScale * 0.9f;
		vector.z = 1f;
		anim.AddTween(12, TweenAnimator.TweenType.Alpha, tutorialObjective.gameObject, num, 1f, num * 2f / 3f, -1, 0f);
		anim.AddTween(from: vector, id: 13, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: tutorialObjective.gameObject, time: num, to: vector2, delay: num * 2f / 3f);
		anim.AddTween(14, TweenAnimator.TweenType.Scale, tutorialObjective.gameObject, num, localScale, 0f, 13);
		anim.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 6)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
			}
		};
		return anim;
	}

	private TweenAnimator CreateAnimatorForHeroic(bool isCoop, bool isCompleted)
	{
		float num = 0.4f;
		TweenAnimator anim = tutorialBackground.transform.parent.gameObject.AddComponent<TweenAnimator>();
		anim.allTweens = new List<TweenAnimator.TweenRecord>();
		AddInitialShowingAnimationToAnimator(ref anim, heroicHeader, heroicHeaderBackground, heroicHeaderName, heroicBackground, heroicFlash);
		anim.AddTween(9, TweenAnimator.TweenType.Alpha, heroicStatus.gameObject, num, 1f, 0f, -1, 0f);
		if (isCompleted)
		{
			anim.AddTween(10, TweenAnimator.TweenType.Alpha, heroicCompletedCheck.gameObject, num, 1f, 0f, -1, 0f);
		}
		Vector3 one = Vector3.one;
		Vector3 vector = new Vector3(1.25f, 1.25f, 1f);
		Vector3 vector2 = new Vector3(0.9f, 0.9f, 1f);
		anim.AddTween(12, TweenAnimator.TweenType.Alpha, heroicObjectiveParent, num, 1f, num * 2f / 3f, -1, 0f);
		TweenAnimator tweenAnimator = anim;
		object obj = vector;
		tweenAnimator.AddTween(13, TweenAnimator.TweenType.Scale, heroicObjectiveParent, num, vector2, num * 2f / 3f, -1, obj);
		anim.AddTween(14, TweenAnimator.TweenType.Scale, heroicObjectiveParent, num, one, 0f, 13);
		Vector3 localPosition = heroicMiddle.transform.localPosition;
		Vector3 vector3 = localPosition + new Vector3(0f, 10f, 0f);
		Vector3 vector4 = localPosition + new Vector3(0f, -20f, 0f);
		float num2 = ((!isCompleted) ? 0.2f : 1f);
		anim.AddTween(17, TweenAnimator.TweenType.Alpha, heroicMiddleBackground.gameObject, num, 1f, num * 2f / 3f, -1, 0f);
		anim.AddTween(18, TweenAnimator.TweenType.Alpha, heroicLeftCorner.gameObject, num, 1f, num * 2f / 3f, -1, 0f);
		anim.AddTween(19, TweenAnimator.TweenType.Alpha, heroicRightCorner.gameObject, num, 1f, num * 2f / 3f, -1, 0f);
		if (isCoop)
		{
			anim.AddTween(20, TweenAnimator.TweenType.Alpha, heroicCoopSkull1.gameObject, num, num2, num * 2f / 3f, -1, 0f);
			anim.AddTween(21, TweenAnimator.TweenType.Alpha, heroicCoopSkull2.gameObject, num, num2, num * 2f / 3f, -1, 0f);
		}
		else
		{
			anim.AddTween(22, TweenAnimator.TweenType.Alpha, heroicSingleSkull.gameObject, num, num2, num * 2f / 3f, -1, 0f);
		}
		TweenAnimator tweenAnimator2 = anim;
		obj = vector4;
		tweenAnimator2.AddTween(23, TweenAnimator.TweenType.Position, heroicMiddle, num, vector3, num * 2f / 3f, -1, obj);
		anim.AddTween(24, TweenAnimator.TweenType.Position, heroicMiddle, num, localPosition, 0f, 23);
		return anim;
	}

	private TweenAnimator CreateAnimatorForVIP(GameObject header, UISprite leftWing, UISprite rightWing, UISprite background, UILabel label, UISprite border, UISprite shadowBorder)
	{
		float time = 0.4f;
		float num = 1.2f;
		float num2 = 0.9f;
		TweenAnimator tweenAnimator = border.transform.parent.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		tweenAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, leftWing.gameObject, time, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(2, TweenAnimator.TweenType.Alpha, rightWing.gameObject, time, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(3, TweenAnimator.TweenType.Alpha, background.gameObject, time, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(4, TweenAnimator.TweenType.Alpha, label.gameObject, time, 1f, 0f, -1, 0f);
		Vector3 localPosition = header.transform.localPosition;
		float y = (num - 1f) * border.transform.localScale.y / 2f;
		float y2 = (num2 - 1f) * border.transform.localScale.y / 2f;
		tweenAnimator.AddTween(from: new Vector3(num, num, 1f), id: 5, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: header.gameObject, time: time, to: new Vector3(num2, num2, 1f), delay: 0f);
		tweenAnimator.AddTween(from: localPosition + new Vector3(0f, y, 0f), id: 6, tweenType: TweenAnimator.TweenType.Position, tweenTarget: header.gameObject, time: time, to: localPosition + new Vector3(0f, y2, 0f), delay: 0f);
		tweenAnimator.AddTween(7, TweenAnimator.TweenType.Scale, header.gameObject, time, Vector3.one, 0f, 5);
		tweenAnimator.AddTween(8, TweenAnimator.TweenType.Position, header.gameObject, time, localPosition, 0f, 6);
		tweenAnimator.AddTween(9, TweenAnimator.TweenType.Alpha, border.gameObject, time, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(10, TweenAnimator.TweenType.Alpha, shadowBorder.gameObject, time, 0.1875f, 0f, -1, 0f);
		Vector3 vector = new Vector3(border.transform.localScale.x * num, border.transform.localScale.y * num, 1f);
		Vector3 vector2 = new Vector3(shadowBorder.transform.localScale.x * num, shadowBorder.transform.localScale.y * num, 1f);
		Vector3 vector3 = new Vector3(border.transform.localScale.x * num2, border.transform.localScale.y * num2, 1f);
		Vector3 vector4 = new Vector3(shadowBorder.transform.localScale.x * num2, shadowBorder.transform.localScale.y * num2, 1f);
		tweenAnimator.AddTween(from: vector, id: 11, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: border.gameObject, time: time, to: vector3, delay: 0f);
		tweenAnimator.AddTween(from: vector2, id: 12, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: shadowBorder.gameObject, time: time, to: vector4, delay: 0f);
		tweenAnimator.AddTween(13, TweenAnimator.TweenType.Scale, border.gameObject, time, border.transform.localScale, 0f, 11);
		tweenAnimator.AddTween(14, TweenAnimator.TweenType.Scale, shadowBorder.gameObject, time, shadowBorder.transform.localScale, 0f, 12);
		tweenAnimator.AddTween(15, TweenAnimator.TweenType.Position, leftWing.gameObject, time, new Vector3(-100f, 39f, 0f), 0f, 7, new Vector3(-35f, 39f, 0f));
		tweenAnimator.AddTween(16, TweenAnimator.TweenType.Position, leftWing.gameObject, time, new Vector3(-90f, 39f, 0f), 0f, 15);
		tweenAnimator.AddTween(17, TweenAnimator.TweenType.Position, rightWing.gameObject, time, new Vector3(100f, 39f, 0f), 0f, 7, new Vector3(35f, 39f, 0f));
		tweenAnimator.AddTween(18, TweenAnimator.TweenType.Position, rightWing.gameObject, time, new Vector3(90f, 39f, 0f), 0f, 17);
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, (Action<int>)delegate(int tweenId)
		{
			if (tweenId == 18 && !Singleton<VipManager>.instance.IsVipActive() && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage3.instance.isTutorialRunning)
			{
				becomeVIP.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
				becomeVIP.SetActive(value: true);
				TweenScale.Begin(becomeVIP, 0.4f, new Vector3(0.001f, 0.001f, 1f), new Vector3(1.2f, 1.2f, 1f)).onFinished = delegate
				{
					TweenScale.Begin(becomeVIP, 0.4f, new Vector3(1f, 1f, 1f)).onFinished = null;
				};
			}
		});
		return tweenAnimator;
	}

	private TweenAnimator CreateAnimatorForCards()
	{
		TweenAnimator tweenAnimator = GuiScreenSingle<EndScreen>.instance.cards.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		float time = 0.4f;
		tweenAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, GuiScreenSingle<EndScreen>.instance.cards.cardsCountLabel.gameObject, time, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(2, TweenAnimator.TweenType.TextCounter, GuiScreenSingle<EndScreen>.instance.cards.cardsCountLabel.gameObject, time, mCardsGot, 0f, 1);
		return tweenAnimator;
	}

	public void InitGuiValues()
	{
		mIsLvlUp = false;
		if (LevelManager.instance.isLevelUp)
		{
			mIsLvlUp = true;
		}
		DatabaseGameReward lastGameReward = Singleton<ServerResultsCache>.instance.lastGameReward;
		mBattleXp.val = lastGameReward?.GetXpBattle() ?? 0;
		mWinXp.val = lastGameReward?.GetXpWin() ?? 0;
		mTimeXp.val = lastGameReward?.GetXpTime() ?? 0;
		mTotalXp.val = lastGameReward?.GetXpTotal() ?? 0;
		int num = (LevelManager.instance.isLevelUp ? LevelManager.instance.previousLevel.golds : 0);
		int warbucks = lastGameReward?.warbucksTotal ?? 0;
		int warbucksVIP = lastGameReward?.warbucksTotalVip ?? 0;
		int gold = ((lastGameReward != null) ? (lastGameReward.goldTotal - num) : 0);
		int goldVIP = ((lastGameReward != null) ? (lastGameReward.goldTotalVip - (int)((float)num * Singleton<VipManager>.instance.vipGoldMultiplier)) : 0);
		mProgress.val = ((!mIsLvlUp) ? LevelManager.instance.GetProgress() : 1f);
		if (Singleton<GameController>.instance.isTutorial)
		{
			mAnimator[1] = mAnimatorTutorial;
		}
		else
		{
			Mission currentMission = MissionsManager.instance.currentMission;
			if (currentMission.playingInHeroicMode)
			{
				bool flag = Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot;
				bool flag2 = Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.MissionSuccess;
				if (flag)
				{
					mAnimator[1] = ((!flag2) ? mAnimatorHeroicCoopLoose : mAnimatorHeroicCoopWin);
				}
				else
				{
					mAnimator[1] = ((!flag2) ? mAnimatorHeroicSingleLoose : mAnimatorHeroicSingleWin);
				}
				heroicHeaderName.text = string.Format("{0} {1}{2} {3}", Localization.Localize("ID_HEROIC"), Colours.stringWhite, Localization.Localize("ID_MISSION"), currentMission.number);
				heroicObjective.text = currentMission.missionObjectiveProgress;
				heroicStatus.text = Localization.Localize((!flag2) ? "ID_FAILED" : "ID_COMPLETED");
				float x = heroicStatus.transform.localPosition.x - heroicStatus.relativeSize.x * heroicStatus.transform.localScale.x - 38f;
				heroicCompletedCheck.transform.localPosition = new Vector3(x, heroicCompletedCheck.transform.localPosition.y, heroicCompletedCheck.transform.localPosition.z);
			}
			else
			{
				mAnimator[1] = mAnimatorMission;
				missionHeaderName.text = string.Format("{0} {1}", Localization.Localize("ID_MISSION"), currentMission.number);
				missionObjective.text = currentMission.missionObjectiveProgress;
			}
		}
		bool isVip = Singleton<VipManager>.instance.IsVipActive();
		VipColors(isVip);
		mAnimator[3] = battleRewards.InitGuiValuesSimple(isVip, warbucks, gold, warbucksVIP, goldVIP, Singleton<Wallet>.instance.warBucks, Singleton<Wallet>.instance.gold);
		InitializeObjects();
		becomeVIP.SetActive(value: false);
		saveReplay.gameObject.SetActive(Recording.recordingEnabled);
	}

	private void VipColors(bool isVip)
	{
		vipLeftWing.color = ((!isVip) ? Colours.whiteVIPShadow : Colours.yellowVIP);
		vipRightWing.color = ((!isVip) ? Colours.whiteVIPShadow : Colours.yellowVIP);
		vipBackground.color = ((!isVip) ? Colours.whiteVIPShadow : Colours.yellowVIP);
		vipBorder.color = ((!isVip) ? Colours.whiteVIPShadow : Colours.yellowVIP);
	}

	private void InitializeObjects()
	{
		experienceXPBackground.alpha = 0f;
		experienceXPLabel.alpha = 0f;
		experienceBorder.alpha = 0f;
		experienceProgressBg.alpha = 0f;
		experienceProgressFg.alpha = 0f;
		experienceNumber.text = "+0";
		experienceNumber.alpha = 0f;
		experienceBonusName.alpha = 0f;
		experienceBonusNumber.alpha = 0f;
		experienceProgressFg.fillAmount = mHeader.progressSprite.fillAmount;
		experienceProgressBg.fillAmount = experienceProgressFg.fillAmount;
		missionFlash.alpha = 0f;
		missionBackground.alpha = 0f;
		missionObjective.alpha = 0f;
		missionHeaderBackground.alpha = 0f;
		missionHeaderName.alpha = 0f;
		star1.alpha = 0f;
		star2.alpha = 0f;
		star3.alpha = 0f;
		starBackground1.alpha = 0f;
		starBackground2.alpha = 0f;
		starBackground3.alpha = 0f;
		missionAlone.SetActive(value: false);
		missionCoop.SetActive(value: false);
		tutorialBackground.alpha = 0f;
		tutorialFlash.alpha = 0f;
		tutorialObjective.alpha = 0f;
		tutorialHeaderBackground.alpha = 0f;
		tutorialHeaderName.alpha = 0f;
		heroicBackground.alpha = 0f;
		heroicFlash.alpha = 0f;
		heroicObjective.alpha = 0f;
		heroicHeaderBackground.alpha = 0f;
		heroicHeaderName.alpha = 0f;
		heroicLeftCorner.alpha = 0f;
		heroicRightCorner.alpha = 0f;
		heroicMiddleBackground.alpha = 0f;
		heroicSingleSkull.alpha = 0f;
		heroicCoopSkull1.alpha = 0f;
		heroicCoopSkull2.alpha = 0f;
		heroicCompletedCheck.alpha = 0f;
		heroicStatus.alpha = 0f;
		vipLeftWing.alpha = 0f;
		vipLeftWing.transform.localPosition = new Vector3(-35f, 39f, 0f);
		vipRightWing.alpha = 0f;
		vipRightWing.transform.localPosition = new Vector3(35f, 39f, 0f);
		vipBackground.alpha = 0f;
		vipEarning.alpha = 0f;
		vipBorder.alpha = 0f;
		vipShadowBorder.alpha = 0f;
	}

	public void AnimateShow(float fadeInTime)
	{
		battleRewards.AnimateShow(fadeInTime);
	}

	internal void StartCoroutineAnimation()
	{
		if (mIsLvlUp)
		{
			StartCoroutine(PlayAnimationTillLevelUp());
		}
		else
		{
			StartCoroutine(PlayAnimation());
		}
	}

	public IEnumerator PlayAnimationTillLevelUp()
	{
		for (int i = 0; i < 1; i++)
		{
			mAnimator[0].PlayTweens();
			yield return new WaitForSeconds(GuiScreenSingle<EndScreen>.instance.timeToShowNextAnimation);
		}
	}

	public void PlayAnimationsAfterLevelUp()
	{
		if (base.gameObject.activeSelf)
		{
			StartCoroutine(PlayAnimation(1));
		}
	}

	public IEnumerator PlayAnimation(int startIndex = 0)
	{
		for (int i = startIndex; i < mAnimator.Count; i++)
		{
			mAnimator[i].PlayTweens();
			yield return new WaitForSeconds(GuiScreenSingle<EndScreen>.instance.timeToShowNextAnimation);
		}
		yield return new WaitForSeconds(0.5f);
		GuiScreenSingle<EndScreen>.instance.pausedShowDialogs = false;
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
		if (!Singleton<VipManager>.instance.IsVipActive() && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage3.instance.isTutorialRunning)
		{
			becomeVIP.SetActive(value: true);
			TweenScale component = becomeVIP.gameObject.GetComponent<TweenScale>();
			if (component != null)
			{
				component.enabled = false;
			}
			becomeVIP.transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}
}
