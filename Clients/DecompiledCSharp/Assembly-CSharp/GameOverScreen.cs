using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : GuiScreenSingle<GameOverScreen>
{
	public enum HitBy
	{
		Unit,
		Player,
		Enviroment
	}

	[Header("Top")]
	public List<UISprite> leftSprites;

	public List<UISprite> rightSprites;

	public UISprite glow;

	public UISprite flash;

	[Header("Bottom")]
	public GameObject box;

	public UIPanel boxPanel;

	public GameObject boxHeader;

	public UILabel boxHeaderLabel;

	public UISprite boxHeaderBackground;

	public GameObject boxBottomPart;

	[Header("-Hit by Unit")]
	public GameObject unitPart;

	public UISprite unitIcon;

	public UISprite cardIcon;

	public UILabel unitName;

	public UILabel unitLevel;

	public UITexture unitTexture;

	[Header("-Hit by Player")]
	public GameObject playerPart;

	public UISprite playerBackground;

	public PlayerIcon playerAvatar;

	public UILabel playerName;

	[Header("-Hit by Environment")]
	public GameObject environmentPart;

	public UISprite environmentSprite;

	public UILabel environmentLabel;

	private Vector3 mLeftSpriteAnimateFrom = new Vector3(-1200f, 0f, 0f);

	private Vector3 mLeftSpriteAnimateTo = new Vector3(0f, 0f, 0f);

	private Vector3 mLeftSpritePosition = new Vector3(-50f, 0f, 0f);

	private Vector3 mLeftSpriteShadow0AnimateTo = new Vector3(-300f, 0f, 0f);

	private Vector3 mLeftSpriteShadow1AnimateTo = new Vector3(-160f, 0f, 0f);

	private Vector3 mLeftAnimationsOffset = new Vector3(0f, 0f, 0f);

	private Vector3 mRightSpriteAnimateFrom = new Vector3(1200f, 0f, 0f);

	private Vector3 mRightSpriteAnimateTo = new Vector3(0f, 0f, 0f);

	private Vector3 mRightSpritePosition = new Vector3(50f, 0f, 0f);

	private Vector3 mRightSpriteShadow0AnimateTo = new Vector3(160f, 0f, 0f);

	private Vector3 mRightSpriteShadow1AnimateTo = new Vector3(300f, 0f, 0f);

	private Vector3 mShiftForOneLanguage = new Vector3(50f, 0f, 0f);

	private Vector3 mBoxHeaderAnimateFrom = new Vector3(0f, -550f, 0f);

	private Vector3 mBoxHeaderAnimateTo = new Vector3(0f, 40f, 0f);

	private Vector3 mBoxHeaderAnimatePosition = new Vector3(0f, -45f, 0f);

	private Vector3 mBoxContentAnimateFrom = new Vector3(0f, -950f, 0f);

	private Vector3 mBoxContentAnimateTo = new Vector3(0f, 0f, 0f);

	private Vector3 mBoxContentAnimatePosition = new Vector3(0f, -95f, 0f);

	private float mAnimationInitialDelayOnWin = 4.3f;

	private float mAnimationInitialDelayOnLost = 2.5f;

	private float mAnimationInitialDelayNoBox = 0.7f;

	private float mAnimationFlyTime = 0.2f;

	private float mAnimationBlinkDelay = 2.4f;

	private float mAnimationFlashTime = 0.4f;

	private float mAnimationShadow0Delay = 0.01f;

	private float mAnimationShadow0Time = 0.4f;

	private float mAnimationShadow0Alpha = 0.6f;

	private float mAnimationShadow0Fadeout = 0.3f;

	private float mAnimationShadow1Alpha = 0.3f;

	private float mAnimationShadow1Delay = 0.2f;

	private float mAnimationShadow1Time = 0.4f;

	private float mAnimationShadow1Fadeout = 0.2f;

	private Vector2 mAnimationGlowScale0 = new Vector2(4000f, 1600f);

	private float mAnimationGlowScale0Time = 0.2f;

	private Vector2 mAnimationGlowScale1 = new Vector2(3000f, 200f);

	private float mAnimationGlowScale1Time = 0.6f;

	private float mAnimationBoxDelay = 0.1f;

	private float mAnimationBoxHeaderFlyTime = 0.2f;

	private float mAnimationBoxHeaderFlyBackTime = 0.4f;

	private float mAnimationBoxContentFlyTime = 0.25f;

	private float mAnimationBoxContentFlyBackTime = 0.2f;

	private float mAnimationBoxHeaderAlpha = 0.5f;

	private float mAnimationBoxHeaderAlphaDelay = 2.5f;

	private float mAnimationBoxHeaderAlphaTime = 0.5f;

	private float mAnimationBlinkHideTime = 0.03f;

	private float mAnimationBlinkShowTime = 0.05f;

	private HitBy mWasHitBy = HitBy.Enviroment;

	private bool mIsWarcard;

	private bool mAnimationFinished;

	private bool mShowAnimationFlash;

	private float mAnimationInitialDelay;

	private bool mAnimationWinSound;

	private Card mKilledByCard;

	private static Dictionary<GameController.GameEndReason, string> youIcon = new Dictionary<GameController.GameEndReason, string>
	{
		{
			GameController.GameEndReason.Win,
			"game-label-you-blue"
		},
		{
			GameController.GameEndReason.WinByForfeit,
			"game-label-you-blue"
		},
		{
			GameController.GameEndReason.MissionSuccess,
			"game-label-you-blue"
		},
		{
			GameController.GameEndReason.Kia,
			"game-label-eliminated"
		},
		{
			GameController.GameEndReason.Killed,
			"game-label-you-red"
		},
		{
			GameController.GameEndReason.MissionFailed,
			"game-label-you-red"
		},
		{
			GameController.GameEndReason.Forfeit,
			"game-label-you-red"
		}
	};

	private static Dictionary<GameController.GameEndReason, string> secondIcon = new Dictionary<GameController.GameEndReason, string>
	{
		{
			GameController.GameEndReason.Win,
			"game-label-won"
		},
		{
			GameController.GameEndReason.WinByForfeit,
			"game-label-won"
		},
		{
			GameController.GameEndReason.MissionSuccess,
			"game-label-won"
		},
		{
			GameController.GameEndReason.Kia,
			string.Empty
		},
		{
			GameController.GameEndReason.Killed,
			"game-label-lose"
		},
		{
			GameController.GameEndReason.MissionFailed,
			"game-label-lose"
		},
		{
			GameController.GameEndReason.Forfeit,
			"game-label-lose"
		}
	};

	private static Dictionary<GameController.GameEndReason, Color> endColor = new Dictionary<GameController.GameEndReason, Color>
	{
		{
			GameController.GameEndReason.Win,
			Colours.blue
		},
		{
			GameController.GameEndReason.WinByForfeit,
			Colours.blue
		},
		{
			GameController.GameEndReason.MissionSuccess,
			Colours.blue
		},
		{
			GameController.GameEndReason.Kia,
			Colours.redLose
		},
		{
			GameController.GameEndReason.Killed,
			Colours.redLose
		},
		{
			GameController.GameEndReason.MissionFailed,
			Colours.redLose
		},
		{
			GameController.GameEndReason.Forfeit,
			Colours.redLose
		}
	};

	public bool isAnimationFinished => mAnimationFinished;

	public void PlayerHit(PlayerController playerControler)
	{
		playerBackground.color = ((playerControler.fraction != PlayerController.currentPlayer.fraction) ? Colours.redEnemy : Colours.blue);
		if (playerControler == PlayerController.currentPlayer)
		{
			playerAvatar.avatar = playerControler.playerProperties.texture;
			playerName.text = playerControler.playerProperties.name;
		}
		else
		{
			playerAvatar.avatar = playerControler.playerProperties.texture;
			playerName.text = playerControler.playerProperties.name;
		}
		mWasHitBy = HitBy.Player;
	}

	public void UnitHit(string unitN, int unitL, string unitSprite, bool isCard)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			unitL = 0;
		}
		if (isCard)
		{
			unitIcon.gameObject.SetActive(value: false);
			unitTexture.gameObject.SetActive(value: false);
			cardIcon.gameObject.SetActive(value: true);
			Card cardInstanceAll = CardManager.instance.GetCardInstanceAll(unitN);
			if (cardInstanceAll != null)
			{
				cardInstanceAll.ShowInMenu();
				mKilledByCard = cardInstanceAll;
				cardIcon.spriteName = cardInstanceAll.iconName;
				unitName.text = cardInstanceAll.cardName;
				unitLevel.text = ((!cardInstanceAll.isBuddyCard) ? string.Empty : Localization.Localize("ID_BUDDYCARD"));
			}
			else
			{
				unitName.text = string.Empty;
				unitLevel.text = string.Empty;
			}
			cardIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(240f / cardIcon.transform.localScale.y, 340f / cardIcon.transform.localScale.x);
			cardIcon.transform.localScale = cardIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			unitTexture.gameObject.SetActive(value: false);
			mKilledByCard = null;
			cardIcon.gameObject.SetActive(value: false);
			unitIcon.gameObject.SetActive(value: true);
			unitIcon.spriteName = unitSprite;
			unitIcon.MakePixelPerfect();
			float multiplier2 = Mathf.Min(240f / unitIcon.transform.localScale.y, 340f / unitIcon.transform.localScale.x);
			unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(multiplier2);
			unitName.text = Localization.Localize(unitN);
			unitLevel.text = ((unitL != 0) ? string.Format("{0} {1}", Localization.Localize("ID_LEVEL"), unitL) : string.Empty);
		}
		MiscTools.SetUILabelRescale(unitName, 52f, 30f);
		mIsWarcard = isCard;
		mWasHitBy = HitBy.Unit;
	}

	public void EnviromentalHit()
	{
		environmentSprite.spriteName = ((!Singleton<MatchManager>.instance.isOverTime) ? "game-kill-environmental" : "game-kill-overtime");
		environmentSprite.MakePixelPerfect();
		environmentLabel.text = ((!Singleton<MatchManager>.instance.isOverTime) ? Localization.Localize("ID_ENVIRONMENTALKILL") : Localization.Localize("ID_OVERTIMEKILL"));
		mWasHitBy = HitBy.Enviroment;
	}

	protected override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		box.GetComponent<UIPanel>().alpha1 = 0f;
		StartCoroutine(RadicalRoutine.Run(OverridePanelDefaultShowing()));
		PrepareAnimation(Singleton<GameController>.instance.gameEndReason);
	}

	public override void OnBack()
	{
	}

	private IEnumerator OverridePanelDefaultShowing()
	{
		yield return new WaitForRealSeconds(0.1f);
		TweenAlpha.Begin(box, 0.05f, 0f, 0f);
		PlayAnimation();
	}

	private bool ShowHitBy(GameController.GameEndReason endReason)
	{
		switch (endReason)
		{
		case GameController.GameEndReason.Killed:
		case GameController.GameEndReason.Win:
			return true;
		case GameController.GameEndReason.MissionSuccess:
			if (MissionsManager.instance.currentMission is BotMission)
			{
				return true;
			}
			break;
		}
		if (endReason == GameController.GameEndReason.MissionFailed && MissionsManager.instance.currentMission is BotMission && PlayerController.currentPlayer.IsDeath())
		{
			return true;
		}
		return false;
	}

	private void SetHeaderTitle(GameController.GameEndReason endReason)
	{
		if (mWasHitBy == HitBy.Unit)
		{
			if (mIsWarcard)
			{
				boxHeaderLabel.text = Localization.Localize("ID_FINALHITBY");
			}
			else
			{
				bool flag = endReason == GameController.GameEndReason.Win || endReason == GameController.GameEndReason.MissionSuccess;
				boxHeaderLabel.text = Localization.Localize((!flag) ? "ID_KILLEDBYENEMYARMYUNIT" : "ID_KILLEDBYYOURARMYUNIT");
			}
		}
		else
		{
			boxHeaderLabel.text = Localization.Localize("ID_FINALHITBY");
		}
		MiscTools.SetUILabelRescale(boxHeaderLabel, 47f, 20f, 710);
	}

	private void PrepareAnimation(GameController.GameEndReason endReason)
	{
		bool flag = endReason == GameController.GameEndReason.Kia;
		TweenScale tweenScale = TweenScale.Begin(boxPanel.transform.parent.gameObject, 0f, Vector3.one);
		tweenScale.onFinished = null;
		string text = youIcon[endReason];
		string text2 = secondIcon[endReason];
		bool flag2 = !string.IsNullOrEmpty(text2);
		foreach (UISprite leftSprite in leftSprites)
		{
			leftSprite.gameObject.SetActive(text != string.Empty);
			if (leftSprite.gameObject.activeSelf)
			{
				leftSprite.spriteName = text;
				leftSprite.MakePixelPerfect();
			}
			TweenAlpha.Begin(leftSprite.gameObject, 0f, 0f);
			TweenPosition.Begin(leftSprite.gameObject, 0f, mLeftSpriteAnimateFrom);
		}
		float num = ((!(text == string.Empty)) ? leftSprites[0].transform.localScale.x : 0f);
		float num2 = 50f + num / 2f;
		mLeftAnimationsOffset = new Vector3((!flag) ? 0f : num2, 0f, 0f);
		foreach (UISprite rightSprite in rightSprites)
		{
			rightSprite.gameObject.SetActive(flag2);
			if (flag2)
			{
				TweenScale component = rightSprite.GetComponent<TweenScale>();
				if (component != null)
				{
					component.enabled = false;
				}
				rightSprite.spriteName = text2;
				rightSprite.MakePixelPerfect();
			}
			TweenAlpha.Begin(rightSprite.gameObject, 0f, 0f);
			TweenPosition.Begin(rightSprite.gameObject, 0f, mRightSpriteAnimateFrom);
		}
		if (flag)
		{
			mLeftSpritePosition = mLeftSpritePosition.ReplaceX(-50f);
			mLeftSpriteAnimateTo = mLeftSpritePosition.ReplaceX(0f);
			mRightSpritePosition = mRightSpritePosition.ReplaceX(50f);
			mRightSpriteAnimateTo = mRightSpritePosition.ReplaceX(0f);
		}
		else
		{
			float num3 = ((!(text2 == string.Empty)) ? rightSprites[0].transform.localScale.x : 0f);
			float num4 = (num + num3) / 2f - num3;
			mLeftSpritePosition = mLeftSpritePosition.ReplaceX(-50f + num4);
			mLeftSpriteAnimateTo = mLeftSpritePosition.ReplaceX(num4);
			mRightSpritePosition = mRightSpritePosition.ReplaceX(50f + num4);
			mRightSpriteAnimateTo = mRightSpritePosition.ReplaceX(num4);
		}
		Color color = endColor[endReason];
		glow.color = color;
		TweenAlpha.Begin(flash.gameObject, 0f, 0f);
		TweenAlpha.Begin(glow.gameObject, 0f, 0f);
		boxHeaderBackground.color = color;
		unitPart.SetActive(mWasHitBy == HitBy.Unit);
		playerPart.SetActive(mWasHitBy == HitBy.Player);
		environmentPart.SetActive(mWasHitBy == HitBy.Enviroment);
		SetHeaderTitle(endReason);
		bool flag3 = ShowHitBy(endReason);
		box.SetActive(flag3);
		boxPanel.alpha1 = 0f;
		TweenAlpha.Begin(boxPanel.gameObject, 0f, 0f);
		TweenAlpha.Begin(boxHeaderBackground.gameObject, 0f, 0f);
		switch (endReason)
		{
		case GameController.GameEndReason.Win:
		case GameController.GameEndReason.WinByForfeit:
		case GameController.GameEndReason.Kia:
		case GameController.GameEndReason.MissionSuccess:
			mAnimationInitialDelay = ((!flag3) ? mAnimationInitialDelayNoBox : mAnimationInitialDelayOnWin);
			mAnimationWinSound = true;
			mShowAnimationFlash = false;
			break;
		case GameController.GameEndReason.Killed:
		case GameController.GameEndReason.Forfeit:
		case GameController.GameEndReason.MissionFailed:
			mAnimationInitialDelay = ((!flag3) ? mAnimationInitialDelayNoBox : mAnimationInitialDelayOnLost);
			mAnimationWinSound = false;
			mShowAnimationFlash = false;
			break;
		}
		mAnimationFinished = false;
	}

	private void PlayAnimation()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(leftSprites[0].gameObject, mAnimationInitialDelay, 0f);
		tweenAlpha.onFinished = delegate
		{
			string currentLanguage = Localization.instance.currentLanguage;
			int num;
			switch (currentLanguage)
			{
			default:
				num = ((currentLanguage == "pt") ? 1 : 0);
				break;
			case "fr":
			case "jp":
			case "cn":
			case "kr":
			case "tc":
				num = 1;
				break;
			}
			bool flag = (byte)num != 0;
			if (flag && Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.Kia)
			{
				flag = false;
			}
			Vector3 vector = ((!flag) ? mLeftSpritePosition : (mLeftSpritePosition + mShiftForOneLanguage));
			Vector3 vector2 = ((!flag) ? mLeftSpriteShadow0AnimateTo : (mLeftSpriteShadow0AnimateTo + mShiftForOneLanguage));
			Vector3 vector3 = ((!flag) ? mLeftSpriteShadow1AnimateTo : (mLeftSpriteShadow1AnimateTo + mShiftForOneLanguage));
			AnimateSide(leftSprites, mLeftSpriteAnimateFrom + mLeftAnimationsOffset, mLeftSpriteAnimateTo + mLeftAnimationsOffset, vector + mLeftAnimationsOffset, vector2 + mLeftAnimationsOffset, vector3 + mLeftAnimationsOffset);
			Vector3 position = ((!flag) ? mRightSpritePosition : (mRightSpritePosition - mShiftForOneLanguage));
			Vector3 shadow0Position = ((!flag) ? mRightSpriteShadow0AnimateTo : (mRightSpriteShadow0AnimateTo - mShiftForOneLanguage));
			Vector3 shadow1Position = ((!flag) ? mRightSpriteShadow1AnimateTo : (mRightSpriteShadow1AnimateTo - mShiftForOneLanguage));
			AnimateSide(rightSprites, mRightSpriteAnimateFrom, mRightSpriteAnimateTo, position, shadow0Position, shadow1Position);
			if (mAnimationWinSound)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.GameOverWin);
				Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateSuccess);
			}
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(flash.gameObject, mAnimationFlyTime, 0f);
			tweenAlpha2.onFinished = delegate
			{
				if (!mAnimationWinSound)
				{
					SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.GameOverLost);
					Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateError);
				}
				float fromAlpha = ((!mShowAnimationFlash) ? 0f : 1f);
				TweenAlpha.Begin(flash.gameObject, mAnimationFlashTime, fromAlpha, 0f);
				TweenAlpha.Begin(glow.gameObject, 0f, 1f);
				TweenScale tweenScale = TweenScale.Begin(glow.gameObject, mAnimationGlowScale0Time, mAnimationGlowScale0, mAnimationGlowScale1);
				tweenScale.onFinished = delegate
				{
					TweenScale.Begin(glow.gameObject, mAnimationGlowScale1Time, mAnimationGlowScale1, new Vector3(0f, 0f, 1f));
				};
			};
			if (box.activeSelf)
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(boxPanel.gameObject, mAnimationBoxDelay, 0f);
				tweenAlpha3.onFinished = delegate
				{
					boxPanel.alpha1 = 1f;
					TweenAlpha.Begin(boxPanel.gameObject, 0f, 1f);
					AnimateBox();
				};
			}
			FlagAnimationEnd();
		};
	}

	private void AnimateSide(List<UISprite> sprites, Vector3 from, Vector3 to, Vector3 position, Vector3 shadow0Position, Vector3 shadow1Position)
	{
		TweenAlpha.Begin(sprites[0].gameObject, 0f, 1f);
		TweenPosition tweenPosition = TweenPosition.Begin(sprites[0].gameObject, mAnimationFlyTime, from, to);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(sprites[0].gameObject, mAnimationFlyTime, to, position);
			tweenPosition2.method = UITweener.Method.EaseIn;
			AnimateShadow(sprites[1], to, shadow0Position, mAnimationShadow0Alpha, mAnimationShadow0Delay, mAnimationShadow0Time, mAnimationShadow0Fadeout);
			AnimateShadow(sprites[2], to, shadow1Position, mAnimationShadow1Alpha, mAnimationShadow1Delay, mAnimationShadow1Time, mAnimationShadow1Fadeout);
		};
		TweenScale tweenScale = TweenScale.Begin(sprites[0].gameObject, mAnimationBlinkDelay, sprites[0].transform.localScale);
		tweenScale.onFinished = delegate
		{
			AnimateBlink(sprites[0].gameObject, mAnimationBlinkHideTime, mAnimationBlinkShowTime, 3);
		};
	}

	private void AnimateShadow(UISprite shadow, Vector3 from, Vector3 to, float alpha, float delay, float flyTime, float fadeout)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(shadow.gameObject, delay, 0f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(shadow.gameObject, 0f, alpha);
			TweenPosition.Begin(shadow.gameObject, flyTime, from, to);
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(shadow.gameObject, flyTime - fadeout, alpha);
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha.Begin(shadow.gameObject, fadeout, alpha, 0f);
			};
		};
	}

	private void AnimateBox()
	{
		TweenAlpha.Begin(boxHeaderBackground.gameObject, 0f, mAnimationBoxHeaderAlpha);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(boxHeaderBackground.gameObject, mAnimationBoxHeaderAlphaDelay, mAnimationBoxHeaderAlpha);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(boxHeaderBackground.gameObject, mAnimationBoxHeaderAlphaTime, mAnimationBoxHeaderAlpha, 1f);
			tweenAlpha2.onFinished = delegate
			{
				AnimateBlink(boxPanel.gameObject, mAnimationBlinkHideTime, mAnimationBlinkShowTime, 3);
			};
		};
		boxHeader.transform.localPosition = mBoxHeaderAnimateFrom;
		TweenPosition tweenPosition = TweenPosition.Begin(boxHeader, mAnimationBoxHeaderFlyTime, mBoxHeaderAnimateFrom, mBoxHeaderAnimateTo);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition3 = TweenPosition.Begin(boxHeader, mAnimationBoxHeaderFlyBackTime, mBoxHeaderAnimateTo, mBoxHeaderAnimatePosition);
			tweenPosition3.method = UITweener.Method.EaseOut;
		};
		boxBottomPart.transform.localPosition = mBoxContentAnimateFrom;
		TweenPosition tweenPosition2 = TweenPosition.Begin(boxBottomPart, mAnimationBoxContentFlyTime, mBoxContentAnimateFrom, mBoxContentAnimateTo);
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = delegate
		{
			TweenPosition tweenPosition3 = TweenPosition.Begin(boxBottomPart, mAnimationBoxContentFlyBackTime, mBoxContentAnimateTo, mBoxContentAnimatePosition);
			tweenPosition3.method = UITweener.Method.EaseOut;
		};
	}

	private void AnimateBlink(GameObject go, float hideTime, float visibleTime, int count, float alpha = 1f)
	{
		if (count == 0)
		{
			TweenAlpha.Begin(go, 0f, 0f);
			return;
		}
		TweenAlpha.Begin(go, 0f, 0f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(go, hideTime, 0f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(go, 0f, alpha);
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(go, visibleTime, alpha);
			tweenAlpha2.onFinished = delegate
			{
				AnimateBlink(go, hideTime, visibleTime, count - 1, alpha);
			};
		};
	}

	private void FlagAnimationEnd()
	{
		float duration = mAnimationFlyTime + mAnimationGlowScale0Time + mAnimationGlowScale1Time + ((!box.activeSelf) ? 2f : 2.5f);
		TweenScale tweenScale = TweenScale.Begin(boxPanel.transform.parent.gameObject, duration, Vector3.one);
		tweenScale.onFinished = delegate
		{
			mAnimationFinished = true;
		};
	}

	protected override void Update()
	{
		base.Update();
		if (mKilledByCard != null && mKilledByCard.iconTexture != null)
		{
			unitTexture.gameObject.SetActive(value: true);
			cardIcon.gameObject.SetActive(value: false);
			unitTexture.mainTexture = mKilledByCard.iconTexture;
			mKilledByCard = null;
		}
	}
}
