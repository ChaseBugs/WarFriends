using System;
using System.Collections.Generic;
using UnityEngine;

public class LeagueResultDialog : GuiElementSingle<LeagueResultDialog>, IGuiDialog
{
	private enum Type
	{
		Demotion,
		Finished,
		Promotion
	}

	[Header("Core")]
	public UISprite background;

	public GameObject dialogCenter;

	[Header("Header")]
	public UILabel title;

	[Header("Middle Part")]
	public UITable table;

	public GameObject bottomItem;

	[Header("-Finished Part")]
	public GameObject fakeTable;

	public UILabel finishedLabel;

	public UILabel finishedPosition;

	public UISprite leftWingFinished;

	public UISprite rightWingFinished;

	[Header("-Description Part")]
	public UILabel description;

	[Header("-Win Bonus Part")]
	public UISprite leftWing;

	public UILabel winBonusLabel;

	public UISprite rightWing;

	[Header("-Money Part")]
	public GameObject warbucksParent;

	public UISprite warbucksBorder;

	public UISprite warbucksIcon;

	public UILabel warbucksLabel;

	public UISprite warbucksFill;

	public GameObject squadPointsParent;

	public UISprite squadPointsBorder;

	public UISprite squadPointsIcon;

	public UILabel squadPointsLabel;

	public UISprite squadPointsFill;

	[Header("Left Part")]
	public UISprite happyDusty;

	public UISprite angryDusty;

	public UITexture leagueTexture;

	[Header("Bottom Part")]
	public GameObject bottomPart;

	public BoxCollider bottomButtonCollider;

	public GameObject bottomButton;

	public UILabel bottomButtonLabel;

	public UISprite bottomButtonBackground;

	[Header("Animation Part")]
	public UITexture previousLeagueIcon;

	public UILabel previousLeagueName;

	public UITexture newLeagueAnimation;

	public UILabel newLeagueName;

	[Header("-Particles")]
	public ParticleSystem particlesBlue;

	public ParticleSystem particlesRed;

	private League mLeague;

	private League mPrevious;

	private int mFinishedPosition;

	private Type mCurrentType = Type.Finished;

	private TweenAnimator mPromoteAnimator;

	private TweenAnimator mStayAnimator;

	private TweenAnimator mDemoteAnimator;

	private float mFlashDur = 0.05f;

	private float mInstaDur = 0.01f;

	private float mDur = 0.2f;

	private float mDelayDur = 0.05f;

	private Vector3 mLeagueNameScale = new Vector3(60f, 60f, 1f);

	private Vector3 mLeagueNameScaleUp = new Vector3(120f, 120f, 1f);

	private Vector3 mLeagueIconScale;

	private Vector3 mLeagueIconScaleUp;

	private Vector3 mLeagueIconScaleBig;

	private Vector3 mLeagueIconPosCenter = new Vector3(280f, 0f, 0f);

	private Vector3 mLeagueIconPosOrig = new Vector3(0f, 0f, 0f);

	private Vector3 mLeagueIconPosLeft = new Vector3(-150f, 0f, 0f);

	private Vector3 mAngrySoldierPosRight = new Vector3(204f, 0f, 0f);

	private Vector3 mAngrySoldierPosOrig = new Vector3(0f, 0f, 0f);

	private Vector3 mAngrySoldierPosLeft = new Vector3(-90f, 0f, 0f);

	private Vector3 mHappySoldierPosRight = new Vector3(229f, -84f, 0f);

	private Vector3 mHappySoldierPosOrig = new Vector3(25f, -84f, 0f);

	private Vector3 mHappySoldierPosLeft = new Vector3(-65f, -84f, 0f);

	private Vector3 mFakeTableOrig;

	private Vector3 mFakeTableUp;

	private Vector3 mFakeTableDown;

	private Vector3 mLeftWingFinishOrig = new Vector3(-378f, 0f, 0f);

	private Vector3 mLeftWingFinishLeft = new Vector3(-421f, 0f, 0f);

	private Vector3 mLeftWingFinishRight = new Vector3(-334f, 0f, 0f);

	private Vector3 mRightWingFinishOrig = new Vector3(378f, 0f, 0f);

	private Vector3 mRightWingFinishLeft = new Vector3(334f, 0f, 0f);

	private Vector3 mRightWingFinishRight = new Vector3(421f, 0f, 0f);

	private Vector3 mDescriptionOrig = new Vector3(-372f, -10f, -1f);

	private Vector3 mDescriptionUp = new Vector3(-372f, 1f, -1f);

	private Vector3 mDescriptionDown = new Vector3(-372f, -36f, -1f);

	private Vector3 mWinOrig = new Vector3(0f, -4f, -1f);

	private Vector3 mWinUp = new Vector3(0f, 10f, -1f);

	private Vector3 mWinDown = new Vector3(0f, -30f, -1f);

	private Vector3 mLeftWingOrig = new Vector3(-372f, 0f, 0f);

	private Vector3 mLeftWingLeft = new Vector3(-419f, 0f, 0f);

	private Vector3 mLeftWingRight = new Vector3(-332f, 0f, 0f);

	private Vector3 mRightWingOrig = new Vector3(372f, 0f, 0f);

	private Vector3 mRightWingLeft = new Vector3(332f, 0f, 0f);

	private Vector3 mRightWingRight = new Vector3(419f, 0f, 0f);

	private Vector3 mWarbucksOrig = new Vector3(-197f, -5f, 0f);

	private Vector3 mWarbucksUp = new Vector3(-197f, 8f, 0f);

	private Vector3 mWarbucksDown = new Vector3(-197f, -30f, 0f);

	private Vector3 mSquadPointsOriginal = new Vector3(197f, -5f, 0f);

	private Vector3 mSquadPointsUp = new Vector3(197f, 8f, 0f);

	private Vector3 mSquadPointsDown = new Vector3(197f, -30f, 0f);

	private Vector3 mButtonOrig = new Vector3(0f, -120f, 0f);

	private Vector3 mButtonUp = new Vector3(0f, -107f, 0f);

	private Vector3 mButtonDown = new Vector3(0f, -145f, 0f);

	private static Dictionary<Type, Tuple<Color, string>> mColorType = new Dictionary<Type, Tuple<Color, string>>
	{
		{
			Type.Demotion,
			new Tuple<Color, string>(Colours.redLeague, Colours.stringRedLeague)
		},
		{
			Type.Finished,
			new Tuple<Color, string>(Colours.blue, Colours.stringBlue)
		},
		{
			Type.Promotion,
			new Tuple<Color, string>(Colours.greenLeague, Colours.stringGreenLeague)
		}
	};

	private static Dictionary<Type, Tuple<string, string>> mStringsInDialog = new Dictionary<Type, Tuple<string, string>>
	{
		{
			Type.Demotion,
			new Tuple<string, string>("ID_LEAGUEDEMOTION", "ID_YOUVEBEENDEMOTEDTO")
		},
		{
			Type.Finished,
			new Tuple<string, string>("ID_LEAGUEFINISHED", "ID_NOTBADYOUVEHOLDYOURGROUND")
		},
		{
			Type.Promotion,
			new Tuple<string, string>("ID_LEAGUEPROMOTION", "ID_GOODJOBYOUVEBEENPROMOTED")
		}
	};

	public void ShowDialog(League previousLeague, League newLeague, int finishedNumber)
	{
		mLeague = newLeague;
		mPrevious = previousLeague;
		mFinishedPosition = finishedNumber;
		mCurrentType = ((newLeague == previousLeague) ? Type.Finished : ((newLeague > previousLeague) ? Type.Promotion : Type.Demotion));
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(bottomButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ButtonClick));
		table.onReposition = delegate
		{
			float num = Mathf.Abs(bottomItem.transform.localPosition.y);
			float num2 = 209f + num + 220f;
			bottomPart.transform.localPosition = bottomPart.transform.localPosition.ReplaceY(0f - num);
			background.transform.localScale = background.transform.localScale.ReplaceY(num2);
			dialogCenter.transform.localPosition = dialogCenter.transform.localPosition.ReplaceY(num2 / 2f);
			StartAnimation();
		};
	}

	private void ButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (mCurrentType == Type.Promotion)
			{
				mPromoteAnimator.FinishTweens();
			}
			else if (mCurrentType == Type.Demotion)
			{
				mDemoteAnimator.FinishTweens();
			}
			else
			{
				mStayAnimator.FinishTweens();
			}
		}
	}

	public override void InitGUIValues()
	{
		title.text = Localization.Localize(mStringsInDialog[mCurrentType].Value1);
		title.color = mColorType[mCurrentType].Value1;
		table.repositionNow = true;
		finishedLabel.text = Localization.Localize("ID_FINISHED");
		finishedPosition.text = MiscTools.FormatNumberToOrdinal(mFinishedPosition);
		finishedLabel.color = ((mCurrentType != Type.Promotion) ? Color.white : Colours.greenLeague);
		finishedPosition.color = finishedLabel.color;
		leftWingFinished.color = mColorType[mCurrentType].Value1;
		rightWingFinished.color = mColorType[mCurrentType].Value1;
		finishedPosition.color = mColorType[mCurrentType].Value1;
		float num = finishedLabel.relativeSize.x * finishedLabel.transform.localScale.x + 22f;
		finishedPosition.transform.localPosition = new Vector3(num, finishedPosition.transform.localPosition.y, finishedPosition.transform.localPosition.z);
		num += finishedPosition.relativeSize.x * finishedPosition.transform.localScale.x;
		fakeTable.transform.localPosition = fakeTable.transform.localPosition.ReplaceX(0f - num / 2f);
		float val = (756f - (num + 64f)) / 2f;
		leftWingFinished.transform.localScale = leftWingFinished.transform.localScale.ReplaceX(val);
		rightWingFinished.transform.localScale = rightWingFinished.transform.localScale.ReplaceX(val);
		description.text = Localization.LocalizeFormat(mStringsInDialog[mCurrentType].Value2, mColorType[mCurrentType].Value2, GameVariables.leagueNames[mLeague].Value1, Colours.stringWhite);
		float num2 = ((mCurrentType != Type.Demotion) ? 55f : 48f);
		description.transform.localScale = new Vector3(num2, num2, 1f);
		val = (744f - (winBonusLabel.relativeSize.x * winBonusLabel.transform.localScale.x + 48f)) / 2f;
		leftWing.transform.localScale = leftWing.transform.localScale.ReplaceX(val);
		rightWing.transform.localScale = rightWing.transform.localScale.ReplaceX(val);
		warbucksLabel.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(mLeague));
		squadPointsLabel.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(mLeague));
		leagueTexture.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[mLeague].Value2);
		leagueTexture.MakePixelPerfect();
		leagueTexture.transform.localScale = leagueTexture.transform.localScale.MultiplyXY(1.44f);
		bottomButtonLabel.text = Localization.Localize((mCurrentType != Type.Promotion) ? "ID_OK" : "ID_AWESOME");
		previousLeagueIcon.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[mPrevious].Value2);
		previousLeagueIcon.MakePixelPerfect();
		previousLeagueIcon.transform.localScale = previousLeagueIcon.transform.localScale.MultiplyXY(1.44f);
		previousLeagueName.text = GameVariables.leagueNames[mPrevious].Value1;
		newLeagueAnimation.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[mLeague].Value2);
		newLeagueName.text = GameVariables.leagueNames[mLeague].Value1;
		bottomButtonCollider.enabled = false;
		SaveChangingPrivateVariables();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		leagueTexture.mainTexture = null;
		previousLeagueIcon.mainTexture = null;
		newLeagueAnimation.mainTexture = null;
	}

	private void StartAnimation()
	{
		HideMiddle();
		InitializeStartPositions();
		if (mCurrentType == Type.Promotion)
		{
			CreateAnimator(ref mPromoteAnimator);
			int idStart = CreateChangeLeagueAnimation(ref mPromoteAnimator);
			CreateRightAnimation(ref mPromoteAnimator, idStart);
			AddSoundsAndParticles(ref mPromoteAnimator);
			mPromoteAnimator.PlayTweens();
		}
		else if (mCurrentType == Type.Demotion)
		{
			CreateAnimator(ref mDemoteAnimator);
			int idStart2 = CreateChangeLeagueAnimation(ref mDemoteAnimator);
			CreateRightAnimation(ref mDemoteAnimator, idStart2);
			AddSoundsAndParticles(ref mDemoteAnimator);
			mDemoteAnimator.PlayTweens();
		}
		else
		{
			CreateAnimator(ref mStayAnimator);
			int idStart3 = CreateStayAnimation(ref mStayAnimator);
			CreateRightAnimation(ref mStayAnimator, idStart3, promoteDemoteIconShow: false);
			AddSoundsAndParticles(ref mStayAnimator);
			mStayAnimator.PlayTweens();
		}
	}

	private void SaveChangingPrivateVariables()
	{
		mLeagueIconScale = leagueTexture.transform.localScale;
		mLeagueIconScaleUp = mLeagueIconScale.MultiplyXY(1.5f);
		mLeagueIconScaleBig = mLeagueIconScale.MultiplyXY(2f);
		mFakeTableOrig = fakeTable.transform.localPosition;
		mFakeTableUp = mFakeTableOrig.AddY(13f);
		mFakeTableDown = mFakeTableOrig.AddY(-20f);
	}

	private void HideMiddle()
	{
		finishedLabel.alpha = 0f;
		finishedPosition.alpha = 0f;
		leftWingFinished.alpha = 0f;
		rightWingFinished.alpha = 0f;
		description.alpha = 0f;
		leftWing.alpha = 0f;
		winBonusLabel.alpha = 0f;
		rightWing.alpha = 0f;
		warbucksBorder.alpha = 0f;
		warbucksIcon.alpha = 0f;
		warbucksLabel.alpha = 0f;
		warbucksFill.alpha = 0f;
		squadPointsBorder.alpha = 0f;
		squadPointsIcon.alpha = 0f;
		squadPointsLabel.alpha = 0f;
		squadPointsFill.alpha = 0f;
		happyDusty.alpha = 0f;
		angryDusty.alpha = 0f;
		leagueTexture.alpha = 0f;
		previousLeagueIcon.alpha = 0f;
		previousLeagueName.alpha = 0f;
		newLeagueAnimation.alpha = 0f;
		newLeagueName.alpha = 0f;
		bottomButtonLabel.alpha = 0f;
		bottomButtonBackground.alpha = 0f;
	}

	private void InitializeStartPositions()
	{
		leagueTexture.transform.localPosition = mLeagueIconPosCenter;
		newLeagueAnimation.transform.localScale = mLeagueIconScale;
	}

	private void CreateAnimator(ref TweenAnimator anim)
	{
		if (anim == null)
		{
			anim = base.gameObject.AddComponent<TweenAnimator>();
			anim.allTweens = new List<TweenAnimator.TweenRecord>();
		}
		else
		{
			anim.allTweens.Clear();
		}
	}

	private int CreateChangeLeagueAnimation(ref TweenAnimator anim)
	{
		float num = 0.7f;
		bool flag = mCurrentType == Type.Demotion;
		GameObject tweenTarget = ((!flag) ? happyDusty.gameObject : angryDusty.gameObject);
		Vector3 vector = ((!flag) ? mHappySoldierPosOrig : mAngrySoldierPosOrig);
		Vector3 vector2 = ((!flag) ? mHappySoldierPosLeft : mAngrySoldierPosLeft);
		Vector3 vector3 = ((!flag) ? mHappySoldierPosRight : mAngrySoldierPosRight);
		anim.AddTween(30, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, fadeInTime, 1f, 0f, -1, 0f);
		anim.AddTween(31, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, fadeInTime, 1f, 0f, -1, 0f);
		anim.AddTween(32, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mFlashDur, 1f, 0f, 30);
		anim.AddTween(33, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mInstaDur, 0f, 0f, 32);
		anim.AddTween(34, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mFlashDur, 0f, 0f, 33);
		anim.AddTween(35, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mInstaDur, 1f, 0f, 34);
		anim.AddTween(36, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mFlashDur, 1f, 0f, 35);
		anim.AddTween(37, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mInstaDur, 0f, 0f, 36);
		anim.AddTween(38, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mFlashDur, 0f, 0f, 37);
		anim.AddTween(39, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mInstaDur, 1f, 0f, 38);
		anim.AddTween(40, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mFlashDur, 1f, 0f, 39);
		anim.AddTween(41, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mFlashDur, 1f, 0f, 30);
		anim.AddTween(42, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mInstaDur, 0f, 0f, 32);
		anim.AddTween(43, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mFlashDur, 0f, 0f, 33);
		anim.AddTween(44, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mInstaDur, 1f, 0f, 34);
		anim.AddTween(45, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mFlashDur, 1f, 0f, 35);
		anim.AddTween(46, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mInstaDur, 0f, 0f, 36);
		anim.AddTween(47, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mFlashDur, 0f, 0f, 37);
		anim.AddTween(48, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mInstaDur, 1f, 0f, 38);
		anim.AddTween(49, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mFlashDur, 0f, 0f, 55);
		anim.AddTween(50, TweenAnimator.TweenType.Alpha, previousLeagueName.gameObject, mFlashDur, 0f, 0f, 48);
		anim.AddTween(51, TweenAnimator.TweenType.Alpha, leagueTexture.gameObject, mFlashDur, 1f, 0f, 40);
		anim.AddTween(from: Vector3.one, id: 52, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: leagueTexture.gameObject, time: mDur, to: mLeagueIconScaleUp, delay: 0f, playAfterIdFinished: 40, method: UITweener.Method.EaseIn);
		anim.AddTween(53, TweenAnimator.TweenType.Scale, leagueTexture.gameObject, mDur * 0.5f, mLeagueIconScale, 0f, 52, null, UITweener.Method.EaseOut);
		anim.AddTween(54, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 1f, 0f, 40);
		anim.AddTween(from: Vector3.one, id: 55, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: newLeagueName.gameObject, time: mDur, to: mLeagueNameScaleUp, delay: 0f, playAfterIdFinished: 40, method: UITweener.Method.EaseIn);
		anim.AddTween(56, TweenAnimator.TweenType.Scale, newLeagueName.gameObject, mDur * 0.5f, mLeagueNameScale, 0f, 55, null, UITweener.Method.EaseOut);
		anim.AddTween(57, TweenAnimator.TweenType.Alpha, newLeagueAnimation.gameObject, mInstaDur, 0.3f, 0f, 52);
		anim.AddTween(59, TweenAnimator.TweenType.Alpha, newLeagueAnimation.gameObject, num + mDur * 0.5f, 0f, 0f, 57);
		anim.AddTween(from: mLeagueIconScaleUp, id: 60, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: newLeagueAnimation.gameObject, time: num + mFlashDur + mDur * 0.5f, to: mLeagueIconScaleBig, delay: 0f, playAfterIdFinished: 52, method: UITweener.Method.EaseOut);
		anim.AddTween(61, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 1f, 0f, 60);
		anim.AddTween(62, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 0f, 0f, 61);
		anim.AddTween(63, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 0f, 0f, 62);
		anim.AddTween(64, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 1f, 0f, 63);
		anim.AddTween(65, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 1f, 0f, 64);
		anim.AddTween(66, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 0f, 0f, 65);
		anim.AddTween(67, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 0f, 0f, 66);
		anim.AddTween(68, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 1f, 0f, 67);
		anim.AddTween(69, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 1f, 0f, 68);
		anim.AddTween(70, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 0f, 0f, 69);
		anim.AddTween(71, TweenAnimator.TweenType.Position, leagueTexture.gameObject, mDur * 2f, mLeagueIconPosLeft, 0f, 60, null, UITweener.Method.EaseIn);
		anim.AddTween(72, TweenAnimator.TweenType.Position, leagueTexture.gameObject, mDur * 1f, mLeagueIconPosOrig, 0f, 71, null, UITweener.Method.EaseOut);
		anim.AddTween(73, TweenAnimator.TweenType.Alpha, tweenTarget, mDur * 1.5f, 1f, 0f, 60, 0f);
		TweenAnimator obj = anim;
		object obj2 = vector3;
		obj.AddTween(74, TweenAnimator.TweenType.Position, tweenTarget, mDur * 2f, vector2, 0f, 60, obj2, UITweener.Method.EaseIn);
		anim.AddTween(75, TweenAnimator.TweenType.Position, tweenTarget, mDur * 1f, vector, 0f, 74, null, UITweener.Method.EaseOut);
		return 60;
	}

	private int CreateStayAnimation(ref TweenAnimator anim)
	{
		float num = 0.7f;
		anim.AddTween(30, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, fadeInTime * 0.33f, 0f, 0f, -1, 0f);
		anim.AddTween(51, TweenAnimator.TweenType.Alpha, leagueTexture.gameObject, mFlashDur, 1f, 0f, 30);
		anim.AddTween(from: Vector3.one, id: 52, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: leagueTexture.gameObject, time: mDur, to: mLeagueIconScaleUp, delay: 0f, playAfterIdFinished: 30, method: UITweener.Method.EaseIn);
		anim.AddTween(53, TweenAnimator.TweenType.Scale, leagueTexture.gameObject, mDur * 0.5f, mLeagueIconScale, 0f, 52, null, UITweener.Method.EaseOut);
		anim.AddTween(54, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 1f, 0f, 30);
		anim.AddTween(from: Vector3.one, id: 55, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: newLeagueName.gameObject, time: mDur, to: mLeagueNameScaleUp, delay: 0f, playAfterIdFinished: 30, method: UITweener.Method.EaseIn);
		anim.AddTween(56, TweenAnimator.TweenType.Scale, newLeagueName.gameObject, mDur * 0.5f, mLeagueNameScale, 0f, 55, null, UITweener.Method.EaseOut);
		anim.AddTween(57, TweenAnimator.TweenType.Alpha, newLeagueAnimation.gameObject, mInstaDur, 0.3f, 0f, 52);
		anim.AddTween(59, TweenAnimator.TweenType.Alpha, newLeagueAnimation.gameObject, num + mDur * 0.5f, 0f, 0f, 57);
		anim.AddTween(from: mLeagueIconScaleUp, id: 60, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: newLeagueAnimation.gameObject, time: num + mFlashDur + mDur * 0.5f, to: mLeagueIconScaleBig, delay: 0f, playAfterIdFinished: 52, method: UITweener.Method.Linear);
		anim.AddTween(61, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 1f, 0f, 60);
		anim.AddTween(62, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 0f, 0f, 61);
		anim.AddTween(63, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 0f, 0f, 62);
		anim.AddTween(64, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 1f, 0f, 63);
		anim.AddTween(65, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 1f, 0f, 64);
		anim.AddTween(66, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 0f, 0f, 65);
		anim.AddTween(67, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 0f, 0f, 66);
		anim.AddTween(68, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 1f, 0f, 67);
		anim.AddTween(69, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mFlashDur, 1f, 0f, 68);
		anim.AddTween(70, TweenAnimator.TweenType.Alpha, newLeagueName.gameObject, mInstaDur, 0f, 0f, 69);
		anim.AddTween(71, TweenAnimator.TweenType.Position, leagueTexture.gameObject, mDur * 2f, mLeagueIconPosLeft, 0f, 60, null, UITweener.Method.EaseIn);
		anim.AddTween(72, TweenAnimator.TweenType.Position, leagueTexture.gameObject, mDur * 1f, mLeagueIconPosOrig, 0f, 71, null, UITweener.Method.EaseOut);
		anim.AddTween(73, TweenAnimator.TweenType.Alpha, happyDusty.gameObject, mDur * 1.5f, 1f, 0f, 60, 0f);
		anim.AddTween(from: mHappySoldierPosRight, id: 74, tweenType: TweenAnimator.TweenType.Position, tweenTarget: happyDusty.gameObject, time: mDur * 2f, to: mHappySoldierPosLeft, delay: 0f, playAfterIdFinished: 60, method: UITweener.Method.EaseIn);
		anim.AddTween(75, TweenAnimator.TweenType.Position, happyDusty.gameObject, mDur * 1f, mHappySoldierPosOrig, 0f, 74, null, UITweener.Method.EaseOut);
		return 60;
	}

	private void CreateRightAnimation(ref TweenAnimator anim, int idStart, bool promoteDemoteIconShow = true)
	{
		anim.AddTween(80, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, 3f * mFlashDur + 2f * mInstaDur, 0f, 0f, idStart, 0f);
		anim.AddTween(81, TweenAnimator.TweenType.Alpha, finishedLabel.gameObject, mDur, 1f, 0f, 80, 0f);
		anim.AddTween(84, TweenAnimator.TweenType.Alpha, finishedPosition.gameObject, mDur, 1f, 0f, 80, 0f);
		anim.AddTween(from: mFakeTableDown, id: 85, tweenType: TweenAnimator.TweenType.Position, tweenTarget: fakeTable, time: mDur, to: mFakeTableUp, delay: 0f, playAfterIdFinished: 80, method: UITweener.Method.EaseIn);
		anim.AddTween(86, TweenAnimator.TweenType.Position, fakeTable, mDur * 0.5f, mFakeTableOrig, 0f, 85, null, UITweener.Method.EaseOut);
		anim.AddTween(87, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mDelayDur, 0f, 0f, 94, 0f);
		anim.AddTween(88, TweenAnimator.TweenType.Alpha, leftWingFinished.gameObject, mDur, 1f, 0f, 87, 0f);
		anim.AddTween(89, TweenAnimator.TweenType.Alpha, rightWingFinished.gameObject, mDur, 1f, 0f, 87, 0f);
		anim.AddTween(from: mLeftWingFinishRight, id: 90, tweenType: TweenAnimator.TweenType.Position, tweenTarget: leftWingFinished.gameObject, time: mDur, to: mLeftWingFinishLeft, delay: 0f, playAfterIdFinished: 87, method: UITweener.Method.EaseIn);
		anim.AddTween(91, TweenAnimator.TweenType.Position, leftWingFinished.gameObject, mDur * 0.5f, mLeftWingFinishOrig, 0f, 90, null, UITweener.Method.EaseOut);
		anim.AddTween(from: mRightWingFinishLeft, id: 92, tweenType: TweenAnimator.TweenType.Position, tweenTarget: rightWingFinished.gameObject, time: mDur, to: mRightWingFinishRight, delay: 0f, playAfterIdFinished: 87, method: UITweener.Method.EaseIn);
		anim.AddTween(93, TweenAnimator.TweenType.Position, rightWingFinished.gameObject, mDur * 0.5f, mRightWingFinishOrig, 0f, 92, null, UITweener.Method.EaseOut);
		anim.AddTween(94, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mDelayDur, 0f, 0f, 80, 0f);
		anim.AddTween(95, TweenAnimator.TweenType.Alpha, description.gameObject, mDur, 1f, 0f, 94, 0f);
		anim.AddTween(from: mDescriptionDown, id: 96, tweenType: TweenAnimator.TweenType.Position, tweenTarget: description.gameObject, time: mDur, to: mDescriptionUp, delay: 0f, playAfterIdFinished: 94, method: UITweener.Method.EaseIn);
		anim.AddTween(97, TweenAnimator.TweenType.Position, description.gameObject, mDur * 0.5f, mDescriptionOrig, 0f, 96, null, UITweener.Method.EaseOut);
		anim.AddTween(98, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mDelayDur, 0f, 0f, 87, 0f);
		anim.AddTween(99, TweenAnimator.TweenType.Alpha, winBonusLabel.gameObject, mDur, 1f, 0f, 98, 0f);
		anim.AddTween(from: mWinDown, id: 100, tweenType: TweenAnimator.TweenType.Position, tweenTarget: winBonusLabel.gameObject, time: mDur, to: mWinUp, delay: 0f, playAfterIdFinished: 98, method: UITweener.Method.EaseIn);
		anim.AddTween(101, TweenAnimator.TweenType.Position, winBonusLabel.gameObject, mDur * 0.5f, mWinOrig, 0f, 100, null, UITweener.Method.EaseOut);
		anim.AddTween(102, TweenAnimator.TweenType.Alpha, leftWing.gameObject, mDur, 1f, 0f, 100, 0f);
		anim.AddTween(103, TweenAnimator.TweenType.Alpha, rightWing.gameObject, mDur, 1f, 0f, 100, 0f);
		anim.AddTween(from: mLeftWingRight, id: 104, tweenType: TweenAnimator.TweenType.Position, tweenTarget: leftWing.gameObject, time: mDur, to: mLeftWingLeft, delay: 0f, playAfterIdFinished: 100, method: UITweener.Method.EaseIn);
		anim.AddTween(105, TweenAnimator.TweenType.Position, leftWing.gameObject, mDur * 0.5f, mLeftWingOrig, 0f, 104, null, UITweener.Method.EaseOut);
		anim.AddTween(from: mRightWingLeft, id: 106, tweenType: TweenAnimator.TweenType.Position, tweenTarget: rightWing.gameObject, time: mDur, to: mRightWingRight, delay: 0f, playAfterIdFinished: 100, method: UITweener.Method.EaseIn);
		anim.AddTween(107, TweenAnimator.TweenType.Position, rightWing.gameObject, mDur * 0.5f, mRightWingOrig, 0f, 106, null, UITweener.Method.EaseOut);
		int playAfterIdFinished = 124;
		mWarbucksOrig = new Vector3(-197f, 0f, 0f);
		mWarbucksUp = new Vector3(-197f, 13f, 0f);
		mWarbucksDown = new Vector3(-197f, -25f, 0f);
		anim.AddTween(108, TweenAnimator.TweenType.Alpha, previousLeagueIcon.gameObject, mDelayDur, 0f, 0f, 98, 0f);
		anim.AddTween(109, TweenAnimator.TweenType.Alpha, warbucksIcon.gameObject, mDur, 1f, 0f, 108, 0f);
		anim.AddTween(110, TweenAnimator.TweenType.Alpha, warbucksLabel.gameObject, mDur, 1f, 0f, 108, 0f);
		anim.AddTween(111, TweenAnimator.TweenType.Alpha, warbucksBorder.gameObject, mDur, 1f, 0f, 108, 0f);
		anim.AddTween(from: mWarbucksDown, id: 112, tweenType: TweenAnimator.TweenType.Position, tweenTarget: warbucksParent, time: mDur, to: mWarbucksUp, delay: 0f, playAfterIdFinished: 108, method: UITweener.Method.EaseIn);
		anim.AddTween(113, TweenAnimator.TweenType.Position, warbucksParent, mDur * 0.5f, mWarbucksOrig, 0f, 112, null, UITweener.Method.EaseOut);
		anim.AddTween(114, TweenAnimator.TweenType.Alpha, warbucksFill.gameObject, mFlashDur, 0.8f, 0f, 113, 0f);
		anim.AddTween(115, TweenAnimator.TweenType.Alpha, warbucksFill.gameObject, mFlashDur, 0.2f, 0f, 114);
		anim.AddTween(116, TweenAnimator.TweenType.Alpha, warbucksFill.gameObject, mFlashDur, 0.8f, 0f, 115);
		anim.AddTween(117, TweenAnimator.TweenType.Alpha, warbucksFill.gameObject, mFlashDur, 0.2f, 0f, 116);
		anim.AddTween(118, TweenAnimator.TweenType.Alpha, warbucksFill.gameObject, mFlashDur, 0.8f, 0f, 117);
		anim.AddTween(119, TweenAnimator.TweenType.Alpha, warbucksFill.gameObject, mFlashDur, 0f, 0f, 118);
		anim.AddTween(121, TweenAnimator.TweenType.Alpha, squadPointsIcon.gameObject, mDur, 1f, 0f, 113, 0f);
		anim.AddTween(122, TweenAnimator.TweenType.Alpha, squadPointsLabel.gameObject, mDur, 1f, 0f, 113, 0f);
		anim.AddTween(123, TweenAnimator.TweenType.Alpha, squadPointsBorder.gameObject, mDur, 1f, 0f, 113, 0f);
		anim.AddTween(from: mSquadPointsDown, id: 124, tweenType: TweenAnimator.TweenType.Position, tweenTarget: squadPointsParent, time: mDur, to: mSquadPointsUp, delay: 0f, playAfterIdFinished: 113, method: UITweener.Method.EaseIn);
		anim.AddTween(125, TweenAnimator.TweenType.Position, squadPointsParent, mDur * 0.5f, mSquadPointsOriginal, 0f, 124, null, UITweener.Method.EaseOut);
		anim.AddTween(126, TweenAnimator.TweenType.Alpha, squadPointsFill.gameObject, mFlashDur, 0.8f, 0f, 125, 0f);
		anim.AddTween(127, TweenAnimator.TweenType.Alpha, squadPointsFill.gameObject, mFlashDur, 0.2f, 0f, 126);
		anim.AddTween(128, TweenAnimator.TweenType.Alpha, squadPointsFill.gameObject, mFlashDur, 0.8f, 0f, 127);
		anim.AddTween(129, TweenAnimator.TweenType.Alpha, squadPointsFill.gameObject, mFlashDur, 0.2f, 0f, 128);
		anim.AddTween(130, TweenAnimator.TweenType.Alpha, squadPointsFill.gameObject, mFlashDur, 0.8f, 0f, 129);
		anim.AddTween(131, TweenAnimator.TweenType.Alpha, squadPointsFill.gameObject, mFlashDur, 0f, 0f, 130);
		anim.AddTween(132, TweenAnimator.TweenType.Alpha, bottomButtonBackground.gameObject, mDur, 1f, 0f, playAfterIdFinished, 0f);
		anim.AddTween(133, TweenAnimator.TweenType.Alpha, bottomButtonLabel.gameObject, mDur, 1f, 0f, playAfterIdFinished, 0f);
		anim.AddTween(from: mButtonDown, id: 134, tweenType: TweenAnimator.TweenType.Position, tweenTarget: bottomButton, time: mDur, to: mButtonUp, delay: 0f, playAfterIdFinished: playAfterIdFinished, method: UITweener.Method.EaseIn);
		anim.AddTween(135, TweenAnimator.TweenType.Position, bottomButton, mDur * 0.5f, mButtonOrig, 0f, 134, null, UITweener.Method.EaseOut);
	}

	private void AddSoundsAndParticles(ref TweenAnimator anim)
	{
		TweenAnimator obj = anim;
		obj.TweenFinished = (Action<int>)Delegate.Combine(obj.TweenFinished, (Action<int>)delegate(int tweenId)
		{
			if (tweenId == 55)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.LeagueIconShowed);
				if (mCurrentType == Type.Promotion)
				{
					particlesBlue.Play();
				}
				else if (mCurrentType == Type.Demotion)
				{
					particlesRed.Play();
				}
			}
			if (tweenId == 114 || tweenId == 126)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.LeagueRewardShowed);
			}
			if (tweenId == 135)
			{
				bottomButtonCollider.enabled = true;
			}
		});
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		if (bottomButtonCollider.enabled)
		{
			ButtonClick(bottomButton.gameObject);
		}
	}
}
