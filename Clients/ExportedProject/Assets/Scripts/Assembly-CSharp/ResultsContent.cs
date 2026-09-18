using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsContent : Core_BaseScript
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

	[Header("Medals")]
	public UISprite medalsBackground;

	public UISprite medalsFlash;

	public UISprite medalsIcon;

	public UILabel medalsNumber;

	public UILabel medalsNotRanked;

	public LeagueArcGuiElement leagueArc;

	[Header("-Header")]
	public GameObject medalsHeader;

	public UISprite medalsHeaderBackground;

	public UILabel medalsHeaderName;

	[Header("Squad Points")]
	public UISprite squadPointsBackground;

	public UISprite squadPointsFlash;

	public UISprite squadPointsIcon;

	public UILabel squadPointsNumber;

	public UILabel squadPointsTotalText;

	public UILabel squadPointsTotalNumber;

	public UILabel squadPointsNotInSquad;

	public UILabel squadPointsNotInSquadJoin;

	public UILabel squadPointsNotRanked;

	public BoxCollider squadPointsButton;

	[Header("-Header")]
	public GameObject squadPointsHeader;

	public UISprite squadPointsHeaderBackground;

	public UILabel squadPointsHeaderName;

	[Header("VIP")]
	public GameObject vipHeader;

	public UISprite vipLeftWing;

	public UISprite vipRightWing;

	public UISprite vipBackground;

	public UILabel vipEarning;

	public UISprite vipBorder;

	public UISprite vipShadowBorder;

	[Header("League Bonus")]
	public ResultsRewardsNA leagueRewards;

	public UISprite leagueIcon;

	public UILabel leagueText;

	[Header("Battle Rewards")]
	public ResultsRewards battleRewards;

	[Header("Winstreak")]
	public ResultsRewardsNA winstreakRewards;

	public UILabel winstreakNumber;

	[Header("-Hint Winstreak")]
	public UIPanel hintButtonPanel;

	public UISprite hintButtonBg;

	public UIPanel hintDialogPanel;

	[Header("-Hint Squad Points")]
	public UIPanel hintSPPanel;

	public UISprite hintSPButtonBg;

	public UIPanel hintSPDialogPanel;

	[Header("Total Earnings")]
	public ResultsRewardsFlash totalRewards;

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

	private bool mIsRanked;

	private IntObject mTotalXp = new IntObject(0);

	private IntObject mWinXp = new IntObject(0);

	private IntObject mTimeXp = new IntObject(0);

	private IntObject mBattleXp = new IntObject(0);

	private FloatObject mProgress = new FloatObject(0f);

	private TweenAnimator mAnimatorMedals;

	private TweenAnimator mAnimatorMedalsNotRanked;

	private TweenAnimator mAnimatorMedalsInLeague;

	private IntObject mMedals = new IntObject(0);

	private IntObject mWeeklyMedalsStart = new IntObject(0);

	private IntObject mWeeklyMedalsEnd = new IntObject(0);

	private TweenAnimator mAnimatorSquadPoints;

	private TweenAnimator mAnimatorSquadPointsNoSquad;

	private TweenAnimator mAnimatorSquadPointsNotRanked;

	private IntObject mSquadPoints = new IntObject(0);

	private IntObject mSquadPointsTotal = new IntObject(0);

	public int cardsGot
	{
		set
		{
			totalRewards.cardsGot = value;
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
		mHeader = GuiElementSingle<MenuHeader>.instance;
		mAnimator.Add(CreateAnimatorForExperience(experienceXPBackground, experienceXPLabel, experienceBorder, experienceProgressFg, experienceProgressBg, experienceNumber, ref mTotalXp, ref mProgress));
		mAnimatorMedals = CreateAnimatorForMedals(medalsIcon, medalsNumber, ref mMedals);
		mAnimatorMedalsInLeague = CreateAnimatorForMedalsInLeague(medalsIcon, medalsNumber, ref mMedals, ref mWeeklyMedalsStart, ref mWeeklyMedalsEnd);
		mAnimatorMedalsNotRanked = CreateAnimatorForMedalsNotRanked(medalsNotRanked);
		mAnimator.Add(mAnimatorMedals);
		leagueArc.InitControls();
		squadPointsNotInSquad.text = Localization.Localize("ID_JOINASQUAD");
		MiscTools.SetUILabelRescale(squadPointsNotInSquad, 32f, 20f, 242);
		squadPointsNotInSquadJoin.text = Localization.Localize("ID_TOGAINPOINTS");
		MiscTools.SetUILabelRescale(squadPointsNotInSquadJoin, 32f, 20f, 242);
		mAnimatorSquadPoints = CreateAnimatorForSquadPoints(null, squadPointsIcon, squadPointsNumber, squadPointsTotalText, squadPointsTotalNumber, null, null, ref mSquadPoints, ref mSquadPointsTotal);
		mAnimatorSquadPointsNoSquad = CreateAnimatorForSquadPoints(null, squadPointsIcon, null, null, null, squadPointsNotInSquad, squadPointsNotInSquadJoin, ref mSquadPoints, ref mSquadPointsTotal);
		mAnimatorSquadPointsNotRanked = CreateAnimatorForSquadPoints(squadPointsNotRanked, null, null, null, null, null, null, ref mSquadPoints, ref mSquadPointsTotal);
		mAnimator.Add(mAnimatorSquadPoints);
		mAnimator.Add(CreateAnimatorForVIP(vipHeader, vipLeftWing, vipRightWing, vipBackground, vipEarning, vipBorder, vipShadowBorder));
		mAnimator.Add(leagueRewards.InitControls(headerAnimation: false));
		mAnimator.Add(battleRewards.InitControls(headerAnimation: false));
		mAnimator.Add(winstreakRewards.InitControls(headerAnimation: false));
		winstreakRewards.animatorMoney.TweenFinished = delegate(int idTween)
		{
			if (idTween == 3 && mIsRanked)
			{
				ShowWinstreakHintButton();
			}
		};
		winstreakRewards.animatorOnlyWB.TweenFinished = delegate(int idTween)
		{
			if (idTween == 3 && mIsRanked)
			{
				ShowWinstreakHintButton();
			}
		};
		winstreakRewards.animatorMoney.TweenFinished = delegate(int idTween)
		{
			if (idTween == 3 && mIsRanked)
			{
				ShowWinstreakHintButton();
			}
		};
		mAnimator.Add(totalRewards.InitControls());
		mAnimator.Add(CreateAnimatorForBecomeVIP());
		UIEventListener.Get(squadPointsButton.gameObject).onClick = SquadPointsClick;
		UIEventListener.Get(hintButtonPanel.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (hintDialogPanel.gameObject.activeSelf)
			{
				HideWinstreakHint();
			}
			else
			{
				ShowWinstreakHint();
			}
		};
		UIEventListener.Get(hintDialogPanel.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HideWinstreakHint();
		};
		UIEventListener.Get(hintSPPanel.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (hintSPDialogPanel.gameObject.activeSelf)
			{
				HideSPHint();
			}
			else
			{
				ShowSPHint();
			}
		};
		UIEventListener.Get(hintSPDialogPanel.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HideSPHint();
		};
		UIEventListener.Get(becomeVIP).onClick = delegate
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		};
		UIEventListener.Get(saveReplay.gameObject).onClick = delegate
		{
			Singleton<Recording>.instance.ShowPreview();
			InvokeAfterRealTime(delegate
			{
				saveReplay.gameObject.SetActive(value: false);
			}, 0.5f);
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

	private void SquadPointsClick(GameObject go)
	{
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
		else
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowSquadWars();
			GuiScreenSingle<LeaguesScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	private void ShowWinstreakHintButton()
	{
		hintButtonPanel.gameObject.SetActive(value: true);
		hintButtonPanel.alpha1 = 0.005f;
		TweenAlpha.Begin(hintButtonPanel.gameObject, 0.4f, 1f);
		hintButtonBg.spriteName = MiscTools.infoButtonSprite;
		hintButtonBg.MakePixelPerfect();
	}

	private void HideWinstreakHint()
	{
		hintButtonBg.spriteName = MiscTools.infoButtonSprite;
		hintButtonBg.MakePixelPerfect();
		TweenAlpha.Begin(hintDialogPanel.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(hintDialogPanel.gameObject, 0.4f, new Vector3(454f, 20f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			hintDialogPanel.gameObject.SetActive(value: false);
		};
	}

	private void ShowWinstreakHint()
	{
		hintButtonBg.spriteName = MiscTools.closeButtonSprite;
		hintButtonBg.MakePixelPerfect();
		hintDialogPanel.gameObject.SetActive(value: true);
		hintDialogPanel.alpha1 = 0.005f;
		TweenAlpha.Begin(hintDialogPanel.gameObject, 0.4f, 1f).onFinished = null;
		hintDialogPanel.transform.localPosition = new Vector3(454f, -20f, -60f);
		TweenPosition tweenPosition = TweenPosition.Begin(hintDialogPanel.gameObject, 0.25f, new Vector3(454f, -20f, -60f), new Vector3(454f, 10f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(hintDialogPanel.gameObject, 0.15f, new Vector3(454f, 0f, -60f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void ShowSPHintButton()
	{
		hintSPPanel.gameObject.SetActive(value: true);
		hintSPPanel.alpha1 = 0.005f;
		TweenAlpha.Begin(hintSPPanel.gameObject, 0.4f, 1f);
		hintSPButtonBg.spriteName = MiscTools.infoButtonSprite;
		hintSPButtonBg.MakePixelPerfect();
	}

	private void HideSPHint()
	{
		hintSPButtonBg.spriteName = MiscTools.infoButtonSprite;
		hintSPButtonBg.MakePixelPerfect();
		TweenAlpha.Begin(hintSPDialogPanel.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(hintSPDialogPanel.gameObject, 0.4f, new Vector3(188f, 114f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			hintSPDialogPanel.gameObject.SetActive(value: false);
		};
	}

	private void ShowSPHint()
	{
		hintSPButtonBg.spriteName = MiscTools.closeButtonSprite;
		hintSPButtonBg.MakePixelPerfect();
		hintSPDialogPanel.gameObject.SetActive(value: true);
		hintSPDialogPanel.alpha1 = 0.005f;
		TweenAlpha.Begin(hintSPDialogPanel.gameObject, 0.4f, 1f).onFinished = null;
		hintSPDialogPanel.transform.localPosition = new Vector3(188f, 74f, -60f);
		TweenPosition tweenPosition = TweenPosition.Begin(hintSPDialogPanel.gameObject, 0.25f, new Vector3(188f, 74f, -60f), new Vector3(188f, 104f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(hintSPDialogPanel.gameObject, 0.15f, new Vector3(188f, 94f, -60f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
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
		TweenPosition.Begin(experienceBonusName.gameObject, dur, new Vector3(74f, 94f, -1f), new Vector3(74f, 142f, -1f)).onFinished = delegate
		{
			TweenPosition.Begin(experienceBonusName.gameObject, dur, new Vector3(74f, 122f, -1f));
			TweenAlpha.Begin(experienceBonusNumber.gameObject, dur, 0f, 1f);
			TweenPosition.Begin(experienceBonusNumber.gameObject, dur, new Vector3(86f, 122f, -1f), new Vector3(132f, 122f, -1f)).onFinished = delegate
			{
				TweenTextCounter.Begin(experienceBonusNumber.gameObject, 0.8f, intObject).onFinished = delegate
				{
					TweenPosition.Begin(experienceBonusName.gameObject, dur, new Vector3(74f, 122f, -1f)).onFinished = delegate
					{
						TweenAlpha.Begin(experienceBonusName.gameObject, dur, 0f);
						TweenPosition.Begin(experienceBonusName.gameObject, dur, new Vector3(74f, 94f, -1f));
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
			float duration = 1f;
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

	private TweenAnimator CreateAnimatorForMedalsNotRanked(UILabel notRanked)
	{
		float time = 0.4f;
		float multiplier = 1.25f;
		float multiplier2 = 0.9f;
		TweenAnimator anim = medalsBackground.transform.parent.gameObject.AddComponent<TweenAnimator>();
		anim.allTweens = new List<TweenAnimator.TweenRecord>();
		AddInitialShowingAnimationToAnimator(ref anim, medalsHeader, medalsHeaderBackground, medalsHeaderName, medalsBackground, medalsFlash);
		Vector3 localScale = notRanked.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(multiplier);
		Vector3 vector2 = localScale.MultiplyXY(multiplier2);
		anim.AddTween(9, TweenAnimator.TweenType.Alpha, notRanked.gameObject, time, 1f, 0f, -1, 0f);
		TweenAnimator tweenAnimator = anim;
		object obj = vector;
		tweenAnimator.AddTween(10, TweenAnimator.TweenType.Scale, notRanked.gameObject, time, vector2, 0f, -1, obj);
		anim.AddTween(11, TweenAnimator.TweenType.Scale, notRanked.gameObject, time, localScale, 0f, 10);
		anim.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 6)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
			}
			if (tweenId == 9)
			{
				AnimateLeagueAndMedals();
			}
		};
		return anim;
	}

	private TweenAnimator CreateAnimatorForMedals(UISprite icon, UILabel number, ref IntObject medalsObject)
	{
		float time = 0.4f;
		float multiplier = 1.25f;
		float multiplier2 = 0.9f;
		TweenAnimator anim = medalsBackground.transform.parent.gameObject.AddComponent<TweenAnimator>();
		anim.allTweens = new List<TweenAnimator.TweenRecord>();
		AddInitialShowingAnimationToAnimator(ref anim, medalsHeader, medalsHeaderBackground, medalsHeaderName, medalsBackground, medalsFlash);
		anim.AddTween(9, TweenAnimator.TweenType.Alpha, icon.gameObject, time, 1f, 0f, -1, 0f);
		anim.AddTween(from: icon.transform.localPosition.AddX(14f), id: 10, tweenType: TweenAnimator.TweenType.Position, tweenTarget: icon.gameObject, time: time, to: icon.transform.localPosition, delay: 0f);
		Vector3 localScale = number.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(multiplier);
		Vector3 vector2 = localScale.MultiplyXY(multiplier2);
		anim.AddTween(12, TweenAnimator.TweenType.Alpha, number.gameObject, time, 1f, 0f, 9, 0f);
		anim.AddTween(13, TweenAnimator.TweenType.Scale, number.gameObject, time, vector2, 0f, 9, vector);
		anim.AddTween(14, TweenAnimator.TweenType.Scale, number.gameObject, time, localScale, 0f, 13);
		anim.AddTween(15, TweenAnimator.TweenType.TextCounter, number.gameObject, 1f, medalsObject, 0f, 14);
		anim.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 6)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
			}
			if (tweenId == 9)
			{
				AnimateLeagueAndMedals();
			}
		};
		return anim;
	}

	private TweenAnimator CreateAnimatorForMedalsInLeague(UISprite icon, UILabel number, ref IntObject medalsObject, ref IntObject medalsWeekS, ref IntObject medalsWeekE)
	{
		float time = 0.4f;
		float multiplier = 1.25f;
		float multiplier2 = 0.9f;
		TweenAnimator anim = medalsBackground.transform.parent.gameObject.AddComponent<TweenAnimator>();
		anim.allTweens = new List<TweenAnimator.TweenRecord>();
		AddInitialShowingAnimationToAnimator(ref anim, medalsHeader, medalsHeaderBackground, medalsHeaderName, medalsBackground, medalsFlash);
		anim.AddTween(9, TweenAnimator.TweenType.Alpha, icon.gameObject, time, 1f, 0f, -1, 0f);
		anim.AddTween(from: icon.transform.localPosition.AddX(14f), id: 10, tweenType: TweenAnimator.TweenType.Position, tweenTarget: icon.gameObject, time: time, to: icon.transform.localPosition, delay: 0f);
		Vector3 localScale = number.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(multiplier);
		Vector3 vector2 = localScale.MultiplyXY(multiplier2);
		anim.AddTween(12, TweenAnimator.TweenType.Alpha, number.gameObject, time, 1f, 0f, 9, 0f);
		anim.AddTween(13, TweenAnimator.TweenType.Scale, number.gameObject, time, vector2, 0f, 9, vector);
		anim.AddTween(14, TweenAnimator.TweenType.Scale, number.gameObject, time, localScale, 0f, 13);
		anim.AddTween(15, TweenAnimator.TweenType.TextCounter, number.gameObject, 1f, medalsObject, 0f, 14);
		anim.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 6)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
			}
			if (tweenId == 9)
			{
				AnimateLeagueAndMedals();
			}
		};
		return anim;
	}

	private void AnimateLeagueAndMedals()
	{
		leagueArc.gameObject.SetActive(value: true);
		leagueArc.StopAnimations();
		LeagueArcData previousData = LeagueArcManager.instance.GetPreviousData();
		leagueArc.InitializeTo(previousData, halfStepInAnimation: true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(leagueArc.gameObject, 0.2f, 0f, 1f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			if (LeagueArcManager.instance.GetWasDataUpdated())
			{
				LeagueArcData currentData = LeagueArcManager.instance.GetCurrentData();
				leagueArc.Animate(previousData, currentData);
				GuiElementSingle<HeaderLeagueButton>.instance.leagueArc.Animate(previousData, currentData);
			}
			else
			{
				leagueArc.ShowLoading();
				GuiElementSingle<HeaderLeagueButton>.instance.leagueArc.ShowLoading();
			}
			GuiElementSingle<HeaderLeagueButton>.instance.AnimateHint();
		});
	}

	private TweenAnimator CreateAnimatorForSquadPoints(UILabel notRanked, UISprite icon, UILabel number, UILabel totalText, UILabel totalNumber, UILabel noSquadHeader, UILabel noSquad, ref IntObject squadPointsObject, ref IntObject squadPointsTotalObject)
	{
		float time = 0.4f;
		float multiplier = 1.25f;
		float multiplier2 = 0.9f;
		TweenAnimator anim = squadPointsBackground.transform.parent.gameObject.AddComponent<TweenAnimator>();
		anim.allTweens = new List<TweenAnimator.TweenRecord>();
		AddInitialShowingAnimationToAnimator(ref anim, squadPointsHeader, squadPointsHeaderBackground, squadPointsHeaderName, squadPointsBackground, squadPointsFlash);
		object obj;
		if (notRanked != null)
		{
			Vector3 localScale = notRanked.transform.localScale;
			Vector3 vector = localScale.MultiplyXY(multiplier);
			Vector3 vector2 = localScale.MultiplyXY(multiplier2);
			anim.AddTween(9, TweenAnimator.TweenType.Alpha, notRanked.gameObject, time, 1f, 0f, -1, 0f);
			TweenAnimator tweenAnimator = anim;
			obj = vector;
			tweenAnimator.AddTween(10, TweenAnimator.TweenType.Scale, notRanked.gameObject, time, vector2, 0f, -1, obj);
			anim.AddTween(11, TweenAnimator.TweenType.Scale, notRanked.gameObject, time, localScale, 0f, 10);
			anim.TweenFinished = delegate(int tweenId)
			{
				if (tweenId == 6)
				{
					SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
				}
				if (tweenId == 9)
				{
					ShowSPHintButton();
				}
				if (tweenId == 11)
				{
					squadPointsButton.enabled = true;
				}
			};
			return anim;
		}
		Vector3 localScale2 = icon.transform.localScale;
		Vector3 vector3 = localScale2.MultiplyXY(multiplier);
		Vector3 vector4 = localScale2.MultiplyXY(multiplier2);
		anim.AddTween(9, TweenAnimator.TweenType.Alpha, icon.gameObject, time, 1f, 0f, -1, 0f);
		TweenAnimator tweenAnimator2 = anim;
		obj = vector3;
		tweenAnimator2.AddTween(10, TweenAnimator.TweenType.Scale, icon.gameObject, time, vector4, 0f, -1, obj);
		anim.AddTween(11, TweenAnimator.TweenType.Scale, icon.gameObject, time, localScale2, 0f, 10);
		if (noSquad != null)
		{
			Vector3 localScale3 = noSquad.transform.localScale;
			Vector3 vector5 = localScale3.MultiplyXY(multiplier);
			Vector3 vector6 = localScale3.MultiplyXY(multiplier2);
			anim.AddTween(12, TweenAnimator.TweenType.Alpha, noSquadHeader.gameObject, time, 1f, 0f, 9, 0f);
			anim.AddTween(13, TweenAnimator.TweenType.Alpha, noSquad.gameObject, time, 1f, 0f, 9, 0f);
			anim.AddTween(14, TweenAnimator.TweenType.Scale, noSquad.gameObject, time, vector6, 0f, 9, vector5);
			anim.AddTween(15, TweenAnimator.TweenType.Scale, noSquad.gameObject, time, localScale3, 0f, 14);
			anim.AddTween(16, TweenAnimator.TweenType.Scale, noSquadHeader.gameObject, time, vector6, 0f, 9, vector5);
			anim.AddTween(17, TweenAnimator.TweenType.Scale, noSquadHeader.gameObject, time, localScale3, 0f, 16);
			anim.TweenFinished = delegate(int tweenId)
			{
				if (tweenId == 6)
				{
					SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
				}
				if (tweenId == 9)
				{
					ShowSPHintButton();
				}
				if (tweenId == 17)
				{
					squadPointsButton.enabled = true;
				}
			};
			return anim;
		}
		Vector3 localScale4 = number.transform.localScale;
		Vector3 vector7 = localScale4.MultiplyXY(multiplier);
		Vector3 vector8 = localScale4.MultiplyXY(multiplier2);
		anim.AddTween(12, TweenAnimator.TweenType.Alpha, number.gameObject, time, 1f, 0f, 9, 0f);
		anim.AddTween(13, TweenAnimator.TweenType.Scale, number.gameObject, time, vector8, 0f, 9, vector7);
		anim.AddTween(14, TweenAnimator.TweenType.Scale, number.gameObject, time, localScale4, 0f, 13);
		anim.AddTween(15, TweenAnimator.TweenType.TextCounter, number.gameObject, time, squadPointsObject, 0f, 14);
		Vector3 localScale5 = totalText.transform.localScale;
		Vector3 vector9 = localScale5.MultiplyXY(multiplier);
		Vector3 vector10 = localScale5.MultiplyXY(multiplier2);
		anim.AddTween(16, TweenAnimator.TweenType.Alpha, totalText.gameObject, time, 1f, 0f, 9, 0f);
		anim.AddTween(17, TweenAnimator.TweenType.Scale, totalText.gameObject, time, vector10, 0f, 9, vector9);
		anim.AddTween(18, TweenAnimator.TweenType.Scale, totalText.gameObject, time, localScale5, 0f, 17);
		Vector3 localScale6 = totalNumber.transform.localScale;
		Vector3 vector11 = localScale6.MultiplyXY(multiplier);
		Vector3 vector12 = localScale6.MultiplyXY(multiplier2);
		anim.AddTween(19, TweenAnimator.TweenType.Alpha, totalNumber.gameObject, time, 1f, 0f, 9, 0f);
		anim.AddTween(20, TweenAnimator.TweenType.Scale, totalNumber.gameObject, time, vector12, 0f, 9, vector11);
		anim.AddTween(21, TweenAnimator.TweenType.Scale, totalNumber.gameObject, time, localScale6, 0f, 20);
		anim.AddTween(22, TweenAnimator.TweenType.TextCounter, totalNumber.gameObject, time, squadPointsTotalObject, 0f, 14);
		anim.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 6)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
			}
			if (tweenId == 9)
			{
				ShowSPHintButton();
			}
			if (tweenId == 22)
			{
				squadPointsButton.enabled = true;
			}
		};
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
		Vector3 vector = border.transform.localScale.MultiplyXY(num);
		Vector3 vector2 = shadowBorder.transform.localScale.MultiplyXY(num);
		Vector3 vector3 = border.transform.localScale.MultiplyXY(num2);
		Vector3 vector4 = shadowBorder.transform.localScale.MultiplyXY(num2);
		object obj = vector;
		tweenAnimator.AddTween(11, TweenAnimator.TweenType.Scale, border.gameObject, time, vector3, 0f, -1, obj);
		obj = vector2;
		tweenAnimator.AddTween(12, TweenAnimator.TweenType.Scale, shadowBorder.gameObject, time, vector4, 0f, -1, obj);
		tweenAnimator.AddTween(13, TweenAnimator.TweenType.Scale, border.gameObject, time, border.transform.localScale, 0f, 11);
		tweenAnimator.AddTween(14, TweenAnimator.TweenType.Scale, shadowBorder.gameObject, time, shadowBorder.transform.localScale, 0f, 12);
		tweenAnimator.AddTween(15, TweenAnimator.TweenType.Position, leftWing.gameObject, time, new Vector3(-100f, 39f, 0f), 0f, 7, new Vector3(-35f, 39f, 0f));
		tweenAnimator.AddTween(16, TweenAnimator.TweenType.Position, leftWing.gameObject, time, new Vector3(-90f, 39f, 0f), 0f, 15);
		tweenAnimator.AddTween(17, TweenAnimator.TweenType.Position, rightWing.gameObject, time, new Vector3(100f, 39f, 0f), 0f, 7, new Vector3(35f, 39f, 0f));
		tweenAnimator.AddTween(18, TweenAnimator.TweenType.Position, rightWing.gameObject, time, new Vector3(90f, 39f, 0f), 0f, 17);
		return tweenAnimator;
	}

	private TweenAnimator CreateAnimatorForBecomeVIP()
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		tweenAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, experienceXPBackground.gameObject, 0.1f, 1f, 0f, -1, 1f);
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, (Action<int>)delegate(int tweenId)
		{
			if (tweenId == 1 && !Singleton<VipManager>.instance.IsVipActive() && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage3.instance.isTutorialRunning)
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

	public void InitGuiValues()
	{
		mIsLvlUp = LevelManager.instance.isLevelUp;
		mIsRanked = Singleton<GameController>.instance.isRandomMatchMaking;
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
		bool isVip = Singleton<VipManager>.instance.IsVipActive();
		bool flag = !StatsManager.instance.winStreak.IsActive() || !mIsRanked;
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag2 = !string.IsNullOrEmpty(squadName);
		bool flag3 = Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.Win || Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.WinByForfeit;
		int remainingMatches = GameLoginManager.currentPlayer.remainingMatches;
		DatabaseGameReward databaseGameReward = Singleton<ServerResultsCache>.instance.lastGameReward;
		if (databaseGameReward == null)
		{
			Debug.Log("ServerResultsCache.instance.lastGameReward == null");
			databaseGameReward = new DatabaseGameReward(0, 0, 0);
		}
		mBattleXp.val = databaseGameReward.GetXpBattle();
		mWinXp.val = databaseGameReward.GetXpWin();
		mTimeXp.val = databaseGameReward.GetXpTime();
		mTotalXp.val = databaseGameReward.GetXpTotal();
		int num = (LevelManager.instance.isLevelUp ? LevelManager.instance.previousLevel.golds : 0);
		int warbucksLeague = databaseGameReward.warbucksLeague;
		int warbucksLeagueVip = databaseGameReward.warbucksLeagueVip;
		int warbucksBattle = databaseGameReward.warbucksBattle;
		int warbucksBattleVip = databaseGameReward.warbucksBattleVip;
		int warbucksWinstreak = databaseGameReward.warbucksWinstreak;
		int warbucksWinstreakVip = databaseGameReward.warbucksWinstreakVip;
		int warbucksTotal = databaseGameReward.warbucksTotal;
		int warbucksTotalVip = databaseGameReward.warbucksTotalVip;
		int goldLeague = databaseGameReward.goldLeague;
		int goldLeagueVip = databaseGameReward.goldLeagueVip;
		int gold = databaseGameReward.goldBattle - num;
		int goldVIP = databaseGameReward.goldBattleVip - (int)((float)num * Singleton<VipManager>.instance.vipGoldMultiplier);
		int goldWinstreak = databaseGameReward.goldWinstreak;
		int goldWinstreakVip = databaseGameReward.goldWinstreakVip;
		int gold2 = databaseGameReward.goldTotal - num;
		int goldVIP2 = databaseGameReward.goldTotalVip - (int)((float)num * Singleton<VipManager>.instance.vipGoldMultiplier);
		long warBucks = Singleton<Wallet>.instance.warBucks;
		long gold3 = Singleton<Wallet>.instance.gold;
		bool flag4 = !databaseGameReward.isInLeague;
		bool isPlayerLeagueProcessing = Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing;
		bool flag5 = isInBeginnersLeague || (!flag4 && !isPlayerLeagueProcessing);
		mMedals.val = databaseGameReward.medalsAllNew - databaseGameReward.medalsAllOld;
		bool flag6 = mMedals.val < 0 || !flag3;
		medalsNumber.color = ((!flag6) ? Colours.blue : Color.red);
		medalsNumber.text = ((!flag6) ? "+0" : "0");
		mWeeklyMedalsStart.val = databaseGameReward.medalsWeeklyOld;
		mWeeklyMedalsEnd.val = databaseGameReward.medalsWeeklyNew;
		mSquadPoints.val = databaseGameReward.squadPoints;
		Debug.Log($"END SCREEN:\nIs matchmaking:{mIsRanked}, No league:{flag4}, Beginners League:{isInBeginnersLeague}, No winstreak:{flag}, Is in squad:{flag2}, Won:{flag3}\nWeekly Medals Start:{mWeeklyMedalsStart.val} End:{mWeeklyMedalsEnd.val}");
		mProgress.val = ((!mIsLvlUp) ? LevelManager.instance.GetProgress() : 1f);
		mAnimator[1] = ((!mIsRanked) ? mAnimatorMedalsNotRanked : ((!flag5) ? mAnimatorMedals : mAnimatorMedalsInLeague));
		squadPointsButton.enabled = false;
		if (mIsRanked)
		{
			mAnimator[2] = ((!flag2) ? mAnimatorSquadPointsNoSquad : mAnimatorSquadPoints);
			squadPointsIcon.spriteName = ((!flag2) ? "menu-squadpoint-ico-bw" : "menu-squadpoint-ico");
			if (flag2)
			{
				mSquadPointsTotal.val = 0;
				squadPointsTotalNumber.text = "0";
				DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(squadName, ommitTime: true);
				if (squad != null)
				{
					mSquadPointsTotal.val = squad.squadPoints;
					squadPointsTotalNumber.text = MiscTools.FormatBigNumber(mSquadPointsTotal.val - mSquadPoints.val);
				}
			}
		}
		else
		{
			mAnimator[2] = mAnimatorSquadPointsNotRanked;
		}
		bool flag7 = isInBeginnersLeague || (!flag4 && !isPlayerLeagueProcessing);
		bool flag8 = !mIsRanked || (mIsRanked && isInBeginnersLeague) || (mIsRanked && !flag4 && !isPlayerLeagueProcessing);
		leagueIcon.spriteName = (isInBeginnersLeague ? Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague) : ((leagueTier != League.NoLeague) ? GameVariables.leagueNames[leagueTier].Value2 : "menu-medals-ico-small"));
		leagueIcon.MakePixelPerfect();
		leagueIcon.alpha = ((!flag7) ? 0.5f : 1f);
		leagueText.lineWidth = ((!flag8) ? 520 : 280);
		leagueText.transform.localScale = ((!flag8) ? new Vector3(35f, 35f, 1f) : new Vector3(42f, 42f, 1f));
		if (mIsRanked)
		{
			if (isInBeginnersLeague)
			{
				leagueText.text = Localization.Localize("ID_GUI_LEAGUEBONUS");
			}
			else if (isPlayerLeagueProcessing)
			{
				leagueText.text = Localization.Localize("ID_PLAYERLEAGUEDATAAREBEINGPROCESSED");
			}
			else if (flag7)
			{
				leagueText.text = Localization.Localize("ID_GUI_LEAGUEBONUS");
			}
			else
			{
				leagueText.text = ((remainingMatches != 1) ? Localization.LocalizeFormat("ID_PLAYXRANKEDBATTLESTOENTERLEAGUE", Colours.stringBlue, remainingMatches, Colours.stringWhite, GameVariables.leagueNames[leagueTier].Value1) : Localization.LocalizeFormat("ID_PLAYRANKEDBATTLETOENTERLEAGUE", Colours.stringBlue, Colours.stringWhite, GameVariables.leagueNames[leagueTier].Value1));
			}
		}
		else
		{
			leagueText.text = Localization.Localize("ID_GUI_LEAGUEBONUS");
		}
		mAnimator[4] = ((!mIsRanked) ? leagueRewards.InitGuiValuesEmpty() : ((!flag7) ? leagueRewards.InitGuiValuesAssign() : leagueRewards.InitGuiValuesSimple(isVip, warbucksLeague, goldLeague, warbucksLeagueVip, goldLeagueVip, warBucks, gold3)));
		mAnimator[5] = battleRewards.InitGuiValuesSimple(isVip, warbucksBattle, gold, warbucksBattleVip, goldVIP, warBucks, gold3);
		winstreakNumber.text = ((!mIsRanked) ? "-" : StatsManager.instance.winStreak.winstreakNumber.ToString());
		mAnimator[6] = ((!flag) ? winstreakRewards.InitGuiValuesSimple(isVip, warbucksWinstreak, goldWinstreak, warbucksWinstreakVip, goldWinstreakVip, warBucks, gold3) : winstreakRewards.InitGuiValuesEmpty());
		mAnimator[7] = totalRewards.InitGuiValuesSimple(isVip, warbucksTotal, gold2, warbucksTotalVip, goldVIP2, warBucks, gold3);
		VipColors(isVip);
		InitializeObjects();
		StopTweensFromBefore();
		becomeVIP.SetActive(value: false);
		saveReplay.gameObject.SetActive(Recording.recordingEnabled);
	}

	public void AddLootboxReward(int lootboxWb)
	{
		totalRewards.Corrections(Singleton<Wallet>.instance.warBucks);
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
		medalsBackground.alpha = 0f;
		medalsFlash.alpha = 0f;
		medalsIcon.alpha = 0f;
		medalsNumber.alpha = 0f;
		medalsNotRanked.alpha = 0f;
		medalsHeaderBackground.alpha = 0f;
		medalsHeaderName.alpha = 0f;
		leagueArc.gameObject.SetActive(value: false);
		squadPointsBackground.alpha = 0f;
		squadPointsFlash.alpha = 0f;
		squadPointsIcon.alpha = 0f;
		squadPointsNumber.text = "+0";
		squadPointsNumber.alpha = 0f;
		squadPointsTotalText.alpha = 0f;
		squadPointsTotalNumber.alpha = 0f;
		squadPointsNotInSquad.alpha = 0f;
		squadPointsNotInSquadJoin.alpha = 0f;
		squadPointsNotRanked.alpha = 0f;
		squadPointsHeaderBackground.alpha = 0f;
		squadPointsHeaderName.alpha = 0f;
		vipLeftWing.alpha = 0f;
		vipLeftWing.transform.localPosition = new Vector3(-35f, 39f, 0f);
		vipRightWing.alpha = 0f;
		vipRightWing.transform.localPosition = new Vector3(35f, 39f, 0f);
		vipBackground.alpha = 0f;
		vipEarning.alpha = 0f;
		vipBorder.alpha = 0f;
		vipShadowBorder.alpha = 0f;
		hintButtonPanel.gameObject.SetActive(value: false);
		hintDialogPanel.gameObject.SetActive(value: false);
		hintSPPanel.gameObject.SetActive(value: false);
		hintSPDialogPanel.gameObject.SetActive(value: false);
	}

	private void StopTweensFromBefore()
	{
		TweenAlpha component = experienceBonusName.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		experienceBonusName.alpha = 0f;
	}

	public void AnimateShow(float fadeInTime)
	{
		leagueRewards.AnimateShow(fadeInTime);
		battleRewards.AnimateShow(fadeInTime);
		winstreakRewards.AnimateShow(fadeInTime);
		totalRewards.AnimateShow(fadeInTime);
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
			float seconds = ((i >= 4) ? (GuiScreenSingle<EndScreen>.instance.timeToShowNextAnimation / 2f) : GuiScreenSingle<EndScreen>.instance.timeToShowNextAnimation);
			yield return new WaitForSeconds(seconds);
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
		if (!leagueArc.gameObject.activeSelf)
		{
			leagueArc.gameObject.SetActive(value: true);
			leagueArc.StopAnimations();
			if (LeagueArcManager.instance.GetWasDataUpdated())
			{
				LeagueArcData currentData = LeagueArcManager.instance.GetCurrentData();
				leagueArc.InitializeTo(currentData);
				GuiElementSingle<HeaderLeagueButton>.instance.leagueArc.InitializeTo(currentData);
			}
			else
			{
				leagueArc.ShowLoading();
				GuiElementSingle<HeaderLeagueButton>.instance.leagueArc.ShowLoading();
			}
			GuiElementSingle<HeaderLeagueButton>.instance.AnimateHint();
		}
	}
}
