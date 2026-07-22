using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DailyMissionButton : Core_BaseScript
{
	[SerializeField]
	[Header("Animation Settings")]
	private float mSpeed = 1f;

	[SerializeField]
	private float mMinX = -20f;

	[SerializeField]
	[Header("Progress")]
	private UISprite mDoneProgress;

	[SerializeField]
	private GameObject mProgressPart;

	[SerializeField]
	private UISprite[] mProgressArrows;

	[SerializeField]
	[Header("Mini Button")]
	private GameObject mPlayButton;

	[SerializeField]
	private UISprite mPlayButtonBackground;

	[SerializeField]
	private UILabel mPlayButtonLabel;

	[SerializeField]
	[Header("Button")]
	private BoxCollider mButtonCollider;

	[SerializeField]
	private UILabel mNumber;

	[SerializeField]
	private GameObject mCompletedPart;

	[SerializeField]
	private GameObject mNormalPart;

	[SerializeField]
	private GameObject mAnimationObject;

	[SerializeField]
	private UISprite mAnimationSprite;

	[SerializeField]
	private GameObject mLockedPart;

	[Header("Normal Parts")]
	[SerializeField]
	private UISprite mNormalBackground;

	[SerializeField]
	private GameObject mSkullObject;

	[SerializeField]
	private UISprite mScullSprite;

	[SerializeField]
	private UISprite mScullPlusSprite;

	[SerializeField]
	[Header("Completed Parts")]
	private UISprite mCompletedBackground;

	[SerializeField]
	private UISprite mCompletedCheck;

	[SerializeField]
	private UILabel mCompletedLabel;

	[Header("Locked Parts")]
	[SerializeField]
	private UISprite mLockedLock;

	[SerializeField]
	private UISprite mLockedBackground;

	[SerializeField]
	private UISprite mLockedSkull;

	[SerializeField]
	private UILabel mLockedLabel;

	[SerializeField]
	[Header("Rewards")]
	private GameObject mRewardsObject;

	[SerializeField]
	private UITable mXPRewardObject;

	[SerializeField]
	private UILabel mXPRewardPoints;

	[SerializeField]
	private UILabel mXPRewardLabel;

	[SerializeField]
	private UITable mWarbucksRewardObject;

	[SerializeField]
	private UILabel mWarbucksRewardAmount;

	[SerializeField]
	private UISprite mWarbucksRewardIcon;

	[Header("Glow")]
	[SerializeField]
	private UISprite mGlow1;

	[SerializeField]
	private UISprite mGlow2;

	private DailyMission DPGPOMCNMNF;

	private bool LALJLMACNJO;

	private float PHEADDEDEMG;

	private float JKBBIKLCPNG;

	private const float MELEEMGPHME = 40f;

	private float AGOCILPHNOB;

	private Vector3 NHIMGLEKLIE;

	private Vector3 IOCFIFJEEGF;

	private Vector3 AKFOIFLDNGI;

	private Vector3 HBEDCLGBJOL;

	private Vector3 GPPBCDLHJMC;

	private Vector3 IGHJLCNFMPG;

	private Vector3 FEFLNBHLEDI;

	private Vector3 MHIAJFBLHEC;

	private Vector3 BFLOBIJCMHE;

	private Vector3 EJELJJMLBGE;

	private Vector3 PDEBIAGFDAL;

	private bool LOOAGDCIEIB => DPGPOMCNMNF != null && !DPGPOMCNMNF.isCoop;

	private void NCIDLAJLKPM(UITweener MMMNJFHDJDC)
	{
		TweenAlpha.Begin(mCompletedLabel.gameObject, 289f, AGOCILPHNOB);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 1864f, 1279f);
		TweenPosition.Begin(mXPRewardLabel.gameObject, 649f, mXPRewardLabel.transform.localPosition.ReplaceY(558f), useLocal: false);
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 1342f, 1410f);
		TweenPosition.Begin(mXPRewardPoints.gameObject, 1667f, mXPRewardPoints.transform.localPosition.ReplaceY(939f)).onFinished = delegate
		{
			if (!LevelManager.instance.isLevelUp)
			{
				ContinueCompletedAnimation();
			}
		};
	}

	[CompilerGenerated]
	private void PHFEEDGCEOL(UITweener BDEOMPEJELN)
	{
		TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.1f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-20f));
	}

	[CompilerGenerated]
	private void JCKHKKPEANG(UITweener AEEBLJKPGMO)
	{
		UISprite[] array = mProgressArrows;
		foreach (UISprite uISprite in array)
		{
			TweenColor.Begin(uISprite.gameObject, 0.2f, Color.black.ReplaceA(0.1f));
		}
		TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
		};
	}

	private void ANNMODBOFOD(UITweener CILHMLFIJJG)
	{
		TweenAlpha.Begin(mDoneProgress.gameObject, 996f, 1871f);
	}

	[CompilerGenerated]
	private void INOENKJFPHB(UITweener NPAJIAIILLL)
	{
		TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
	}

	[CompilerGenerated]
	private void EMKOENPNMCO(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 1f);
		TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f), mWarbucksRewardAmount.transform.localPosition.ReplaceY(0f)).onFinished = delegate
		{
			TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.1f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-20f));
		};
	}

	[CompilerGenerated]
	private void ECPPKJEEBDL(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mPlayButton, 0.1f, mPlayButton.transform.localPosition.ReplaceY(154f));
	}

	private void NIGOADNHHFC()
	{
		if (LALJLMACNJO && mSpeed > 1528f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			EEGNAKPEJFE(num / mSpeed, KAKIMEJCEFA: true);
		}
	}

	public void CBINNKNCCML()
	{
		BEKHAHCBGLF();
		mButtonCollider.enabled = DebugSettings.debugEnabled;
		if (LOOAGDCIEIB)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 884f, 1881f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 1162f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(1007f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(1233f)).onFinished = delegate
			{
				TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.1f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-20f));
			};
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 528f, 933f).onFinished = delegate
			{
				TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 1f);
				TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f), mWarbucksRewardAmount.transform.localPosition.ReplaceY(0f)).onFinished = delegate
				{
					TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.1f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-20f));
				};
			};
		}
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1878f, 1738f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 279f, 679f);
		TweenPosition.Begin(mPlayButton, 1552f, mPlayButton.transform.localPosition.AddY(1049f), useLocal: false).onFinished = ODBAILNEPFI;
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-115), 593f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 56f, IOCFIFJEEGF.MultiplyXY(1907f));
		TweenScale.Begin(mSkullObject, 1477f, Vector3.one, Vector3.one.MultiplyXY(996f)).onFinished = HCHGALBHEKP;
	}

	[CompilerGenerated]
	private void HBBPHKADEBL(UITweener AAHDNEKFJOA)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
		{
			TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
			TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
			TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
			TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
			TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
			{
				if (!LevelManager.instance.isLevelUp)
				{
					ContinueCompletedAnimation();
				}
			};
		};
	}

	private void GBPJDPAOIKD(UITweener AAHDNEKFJOA)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 754f, 1623f).onFinished = NCIDLAJLKPM;
	}

	public void ABJOHDHGBNH()
	{
		GuiScreenSingle<DailyMissionScreen>.instance.AKMMIBPJLHH();
		if (DPGPOMCNMNF == null || !DPGPOMCNMNF.isSolo || DPGPOMCNMNF.number == 8)
		{
			GuiScreenSingle<DailyMissionScreen>.instance.CEIPCDDFMJB();
		}
	}

	private void HILKOBFABLE(UITweener AAHDNEKFJOA)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 5f, 991f).onFinished = NCIDLAJLKPM;
	}

	private void HCOMPJGMAJB(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mXPRewardLabel.gameObject, 1130f, mXPRewardLabel.transform.localPosition.ReplaceY(797f));
	}

	public void ContinueCompletedAnimation()
	{
		GuiScreenSingle<DailyMissionScreen>.instance.EndAnimation();
		if (DPGPOMCNMNF != null && DPGPOMCNMNF.isSolo && DPGPOMCNMNF.number == 3)
		{
			GuiScreenSingle<DailyMissionScreen>.instance.AnimateDaily3SoloReward();
		}
	}

	private void BNLDOFKKEFL(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mPlayButton, 1036f, mPlayButton.transform.localPosition.ReplaceY(1177f), useLocal: false);
		UISprite[] array = mProgressArrows;
		foreach (UISprite uISprite in array)
		{
			TweenColor.Begin(uISprite.gameObject, 827f, Color.white);
		}
		TweenAlpha.Begin(mLockedBackground.gameObject, 1920f, 1767f);
		TweenScale.Begin(mLockedBackground.gameObject, 1536f, PDEBIAGFDAL.MultiplyXY(304f));
		TweenScale.Begin(mNormalBackground.gameObject, 1020f, IGHJLCNFMPG);
		TweenAlpha.Begin(mScullSprite.gameObject, 867f, 388f);
		TweenScale.Begin(mScullSprite.gameObject, 1611f, HBEDCLGBJOL.MultiplyXY(458f), HBEDCLGBJOL.MultiplyXY(1312f)).onFinished = DBOPAHECCPP;
	}

	public void BOKDLIFGIDO(DailyMission EHIPMLOMMIG, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		DPGPOMCNMNF = EHIPMLOMMIG;
		AFIAPIFAAFC();
		mButtonCollider.enabled = !GIAFDDAKALM && DebugSettings.debugEnabled;
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(DPGPOMCNMNF.number);
		mNormalPart.SetActive(GIAFDDAKALM);
		mCompletedPart.SetActive(ECEOFMAEOGE);
		mLockedPart.gameObject.SetActive(ECEOFMAEOGE || GIAFDDAKALM);
		if (GIAFDDAKALM && !EHIPMLOMMIG.isCoop)
		{
			CJDIEHOOPHG();
		}
		else if (GIAFDDAKALM)
		{
			mAnimationObject.transform.localScale = new Vector3(1862f, 1912f, 1029f);
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(!GIAFDDAKALM && ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 982f;
		EDMIHHBPOCE(580f, KAKIMEJCEFA: true);
		BPHIDCOEOAG(ECEOFMAEOGE);
	}

	private void HCONJNDIBKD(UITweener AKCKHOODNAI)
	{
		TweenPosition.Begin(mXPRewardPoints.gameObject, 286f, mXPRewardPoints.transform.localPosition.ReplaceY(1818f), useLocal: false).onFinished = GIHPPCJNKLK;
	}

	private void ODIMCMILLMB(UITweener CILHMLFIJJG)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 1937f, 918f);
		TweenPosition.Begin(mXPRewardPoints.gameObject, 814f, mXPRewardPoints.transform.localPosition.ReplaceY(1432f), mXPRewardPoints.transform.localPosition.ReplaceY(689f)).onFinished = MEAGKLAOJIH;
	}

	private void MNEOBJLNDCN(UITweener MMMNJFHDJDC)
	{
		TweenAlpha.Begin(mCompletedLabel.gameObject, 517f, AGOCILPHNOB);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 1797f, 1408f);
		TweenPosition.Begin(mXPRewardLabel.gameObject, 842f, mXPRewardLabel.transform.localPosition.ReplaceY(632f), useLocal: false);
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 1126f, 736f);
		TweenPosition.Begin(mXPRewardPoints.gameObject, 1440f, mXPRewardPoints.transform.localPosition.ReplaceY(459f)).onFinished = delegate
		{
			if (!LevelManager.instance.isLevelUp)
			{
				ContinueCompletedAnimation();
			}
		};
	}

	public void KJGMGIEGBID()
	{
		BEKHAHCBGLF();
		mButtonCollider.enabled = DebugSettings.debugEnabled;
		if (LOOAGDCIEIB)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 621f, 1428f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 772f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(1055f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(71f)).onFinished = CIFMAANPMAN;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 943f, 1201f).onFinished = ENEAFIFPLGJ;
		}
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 57f, 341f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 618f, 1028f);
		TweenPosition.Begin(mPlayButton, 823f, mPlayButton.transform.localPosition.AddY(775f)).onFinished = delegate
		{
			TweenPosition.Begin(mPlayButton, 0.1f, mPlayButton.transform.localPosition.ReplaceY(154f));
		};
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-43), 1835f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 1522f, IOCFIFJEEGF.MultiplyXY(1894f));
		TweenScale.Begin(mSkullObject, 363f, Vector3.one, Vector3.one.MultiplyXY(278f)).onFinished = HCHGALBHEKP;
	}

	private void MNHHFAJFEAH(UITweener AEEBLJKPGMO)
	{
		UISprite[] array = mProgressArrows;
		for (int i = 1; i < array.Length; i++)
		{
			UISprite uISprite = array[i];
			TweenColor.Begin(uISprite.gameObject, 437f, Color.black.ReplaceA(1318f));
		}
		TweenAlpha.Begin(mScullSprite.gameObject, 748f, 110f).onFinished = delegate
		{
			TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
		};
	}

	public void KDPPCIMMMEK()
	{
		IDOHCKKEGNE();
		mButtonCollider.enabled = false;
		TweenAlpha.Begin(mGlow1.gameObject, 1253f, 1782f).onFinished = delegate
		{
			TweenAlpha.Begin(mGlow1.gameObject, 0.6f, 1f);
			TweenAlpha.Begin(mGlow2.gameObject, 0.6f, 1f).onFinished = delegate
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StarGained);
				if (LOOAGDCIEIB)
				{
					DOINHAEFDNB();
				}
				TweenAlpha.Begin(mLockedLabel.gameObject, 0.3f, 0f);
				TweenAlpha.Begin(mLockedLock.gameObject, 0.3f, 0f);
				TweenScale.Begin(mLockedLock.gameObject, 0.3f, EJELJJMLBGE.MultiplyXY(2f));
				TweenAlpha.Begin(mLockedSkull.gameObject, 0.3f, 0f);
				TweenAlpha.Begin(mNormalBackground.gameObject, 0.3f, 1f);
				TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0.3f, 1f);
				TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0.3f, 1f);
				TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.AddY(30f));
				TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG.MultiplyXY(2f), IGHJLCNFMPG.MultiplyXY(0.8f)).onFinished = delegate
				{
					TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.ReplaceY(154f));
					UISprite[] array = mProgressArrows;
					foreach (UISprite uISprite in array)
					{
						TweenColor.Begin(uISprite.gameObject, 0.5f, Color.white);
					}
					TweenAlpha.Begin(mLockedBackground.gameObject, 0.6f, 0f);
					TweenScale.Begin(mLockedBackground.gameObject, 0.5f, PDEBIAGFDAL.MultiplyXY(2f));
					TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG);
					TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f);
					TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL.MultiplyXY(1.5f), HBEDCLGBJOL.MultiplyXY(0.8f)).onFinished = delegate
					{
						TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL);
						TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 1f);
						TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF.MultiplyXY(1.5f), IOCFIFJEEGF.MultiplyXY(0.8f)).onFinished = delegate
						{
							TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
						};
					};
				};
			};
		};
	}

	private void KPKPEAENAHB()
	{
		Vector3 vector = new Vector3(1605f, 875f, 1402f);
		TweenScale tweenScale = TweenScale.Begin(mAnimationObject, 216f, vector, vector.MultiplyXY(146f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mAnimationSprite.gameObject, 1713f, 913f, 1490f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	private void HCHGALBHEKP(UITweener LPICCDPEOKA)
	{
		TweenPosition.Begin(mScullPlusSprite.gameObject, 540f, NHIMGLEKLIE.AddY(1601f), useLocal: false);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 488f, 1112f);
		TweenScale.Begin(mSkullObject, 162f, Vector3.one);
		TweenPosition.Begin(mScullSprite.gameObject, 111f, AKFOIFLDNGI, useLocal: false).onFinished = delegate
		{
			TweenAlpha.Begin(mGlow1.gameObject, 0.6f, 0f);
			TweenAlpha.Begin(mGlow2.gameObject, 0.6f, 0f);
			TweenPosition.Begin(mNormalBackground.gameObject, 0.1f, GPPBCDLHJMC).onFinished = delegate
			{
				if (LOOAGDCIEIB)
				{
					TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
					TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
				}
				TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
				TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
				TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
				TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
				{
					TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
				};
			};
			TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI).onFinished = delegate
			{
				if (LOOAGDCIEIB)
				{
					TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 1f);
					TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f), mXPRewardLabel.transform.localPosition.ReplaceY(0f)).onFinished = delegate
					{
						TweenPosition.Begin(mXPRewardLabel.gameObject, 0.1f, mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
					};
					TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.1f, 0f).onFinished = delegate
					{
						TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 1f);
						TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f), mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = delegate
						{
							TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
							{
								TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
								{
									TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
									TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
									TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
									TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
									TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
									{
										if (!LevelManager.instance.isLevelUp)
										{
											ContinueCompletedAnimation();
										}
									};
								};
							};
						};
					};
				}
				TweenScale.Begin(mCompletedCheck.gameObject, 0.2f, BFLOBIJCMHE.MultiplyXY(3f), BFLOBIJCMHE);
				TweenAlpha.Begin(mCompletedCheck.gameObject, 0.2f, 1f);
				TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI.AddY(30f), FEFLNBHLEDI);
				TweenAlpha.Begin(mCompletedBackground.gameObject, 0.2f, 1f);
			};
			TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f).onFinished = delegate
			{
				UISprite[] array = mProgressArrows;
				foreach (UISprite uISprite in array)
				{
					TweenColor.Begin(uISprite.gameObject, 0.2f, Color.black.ReplaceA(0.1f));
				}
				TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 0f).onFinished = delegate
				{
					TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
				};
			};
			TweenPosition.Begin(mScullSprite.gameObject, 0.4f, GuiScreenSingle<DailyMissionScreen>.instance.positionToAnimatePointsGain, useLocal: false);
		};
	}

	private void BGCFFANNGBM(UITweener KDMCDGPHBCF)
	{
		TweenScale.Begin(mScullSprite.gameObject, 696f, HBEDCLGBJOL);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 212f, 885f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 1498f, IOCFIFJEEGF.MultiplyXY(1070f), IOCFIFJEEGF.MultiplyXY(1765f)).onFinished = EMBAKBEMOGN;
	}

	public void CIBLFMHHPDA(DailyMission EHIPMLOMMIG, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		DPGPOMCNMNF = EHIPMLOMMIG;
		AFIAPIFAAFC();
		mButtonCollider.enabled = GIAFDDAKALM || DebugSettings.debugEnabled;
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(DPGPOMCNMNF.number);
		mNormalPart.SetActive(GIAFDDAKALM);
		mCompletedPart.SetActive(ECEOFMAEOGE);
		mLockedPart.gameObject.SetActive(ECEOFMAEOGE || !GIAFDDAKALM);
		if (GIAFDDAKALM && !EHIPMLOMMIG.isCoop)
		{
			MBCHNOCPGDB();
		}
		else if (GIAFDDAKALM)
		{
			mAnimationObject.transform.localScale = new Vector3(118f, 1852f, 575f);
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(!GIAFDDAKALM && ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 164f;
		EDMIHHBPOCE(538f);
		LOEEEMPEGJM(ECEOFMAEOGE);
	}

	private void JJBDAMAFBNC(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1563f)
		{
			PAENPHMEMGC = 1377f;
		}
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num = 1717f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 1917f * (484f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	public void GBLKCBLHNHC(DailyMission EHIPMLOMMIG, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		DPGPOMCNMNF = EHIPMLOMMIG;
		AFIAPIFAAFC();
		mButtonCollider.enabled = GIAFDDAKALM || DebugSettings.debugEnabled;
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(DPGPOMCNMNF.number);
		mNormalPart.SetActive(GIAFDDAKALM);
		mCompletedPart.SetActive(ECEOFMAEOGE);
		mLockedPart.gameObject.SetActive(ECEOFMAEOGE || !GIAFDDAKALM);
		if (GIAFDDAKALM && !EHIPMLOMMIG.isCoop)
		{
			MBCHNOCPGDB();
		}
		else if (GIAFDDAKALM)
		{
			mAnimationObject.transform.localScale = new Vector3(183f, 154f, 1630f);
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(!GIAFDDAKALM && ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 1406f;
		EEGNAKPEJFE(239f, KAKIMEJCEFA: true);
		ADCCFCDFNGI(ECEOFMAEOGE);
	}

	[CompilerGenerated]
	private void AOEJHOCDLJI(UITweener AKCKHOODNAI)
	{
		TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
		{
			TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
				TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
				TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
				{
					if (!LevelManager.instance.isLevelUp)
					{
						ContinueCompletedAnimation();
					}
				};
			};
		};
	}

	private void EECEGLNCGNG()
	{
		NHIMGLEKLIE = mScullPlusSprite.transform.localPosition;
		IOCFIFJEEGF = mScullPlusSprite.transform.localScale;
		AKFOIFLDNGI = mScullSprite.transform.localPosition;
		HBEDCLGBJOL = mScullSprite.transform.localScale;
		GPPBCDLHJMC = mNormalBackground.transform.localPosition;
		IGHJLCNFMPG = mNormalBackground.transform.localScale;
		FEFLNBHLEDI = mCompletedBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		BFLOBIJCMHE = mCompletedCheck.transform.localScale;
		EJELJJMLBGE = mLockedLock.transform.localScale;
		PDEBIAGFDAL = mLockedBackground.transform.localScale;
	}

	private void EMBAKBEMOGN(UITweener NPAJIAIILLL)
	{
		TweenScale.Begin(mScullPlusSprite.gameObject, 1295f, IOCFIFJEEGF);
	}

	private void IGGFLDFBGEN(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 257f)
		{
			PAENPHMEMGC = 427f;
		}
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			float num = 1908f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 1497f * (177f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void DPNCIHJJHME(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mPlayButton, 248f, mPlayButton.transform.localPosition.ReplaceY(1817f));
	}

	private void AGNMPMACAID()
	{
		if (LOOAGDCIEIB)
		{
			foreach (CDACJEGCGLB reward in DPGPOMCNMNF.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 1156f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 1788f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(257f - num / 1037f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(1311f - num2 / 914f);
			mXPRewardObject.repositionNow = false;
			mWarbucksRewardObject.repositionNow = false;
		}
		mAnimationObject.SetActive(value: true);
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = false;
		mNormalPart.SetActive(value: true);
		mCompletedPart.SetActive(value: true);
		TweenAlpha.Begin(mDoneProgress.gameObject, 1852f, 641f);
		TweenAlpha.Begin(mCompletedBackground.gameObject, 905f, 396f);
		TweenAlpha.Begin(mCompletedCheck.gameObject, 529f, 1714f);
		TweenAlpha.Begin(mCompletedLabel.gameObject, 1904f, 291f);
		BPHIDCOEOAG(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	private void DDBGCKOKBKI(UITweener KDMCDGPHBCF)
	{
		TweenScale.Begin(mScullSprite.gameObject, 287f, HBEDCLGBJOL);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 966f, 1873f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 1630f, IOCFIFJEEGF.MultiplyXY(1883f), IOCFIFJEEGF.MultiplyXY(238f)).onFinished = delegate
		{
			TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
		};
	}

	public void KIKCJMILKLG()
	{
		TweenAlpha.Begin(mAnimationSprite.gameObject, 1599f, 1836f, 1416f);
		mNormalPart.SetActive(value: false);
		mLockedPart.SetActive(value: false);
		mProgressPart.SetActive(value: false);
		LALJLMACNJO = false;
		BPHIDCOEOAG(ECEOFMAEOGE: false);
		TweenAlpha.Begin(mGlow1.gameObject, 96f, 737f);
		TweenAlpha.Begin(mGlow2.gameObject, 1652f, 1925f);
		TweenAlpha.Begin(mGlow2.gameObject, 1246f, 1511f);
		TweenAlpha.Begin(mNormalBackground.gameObject.gameObject, 193f, 1757f);
		TweenAlpha.Begin(mScullSprite.gameObject, 1752f, 1611f);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 1320f, 1132f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1788f, 711f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 675f, 1479f);
	}

	public void AJALIOBIGCK(DailyMission EHIPMLOMMIG, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		DPGPOMCNMNF = EHIPMLOMMIG;
		AKHNNNLPHGC();
		mButtonCollider.enabled = GIAFDDAKALM || DebugSettings.debugEnabled;
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(DPGPOMCNMNF.number);
		mNormalPart.SetActive(GIAFDDAKALM);
		mCompletedPart.SetActive(ECEOFMAEOGE);
		mLockedPart.gameObject.SetActive(!ECEOFMAEOGE && !GIAFDDAKALM);
		if (GIAFDDAKALM && !EHIPMLOMMIG.isCoop)
		{
			MBCHNOCPGDB();
		}
		else if (GIAFDDAKALM)
		{
			mAnimationObject.transform.localScale = new Vector3(806f, 836f, 916f);
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 1245f;
		EDMIHHBPOCE(306f, KAKIMEJCEFA: true);
		BPHIDCOEOAG(ECEOFMAEOGE);
	}

	private void LDFMHJJEIAP(UITweener AAHDNEKFJOA)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 1447f, 1585f).onFinished = NCIDLAJLKPM;
	}

	[CompilerGenerated]
	private void HCMLNIDGONE(UITweener CILHMLFIJJG)
	{
		TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
	}

	private void BFAAJFKILAK(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mGlow1.gameObject, 1061f, 258f);
		TweenAlpha.Begin(mGlow2.gameObject, 17f, 1254f);
		TweenPosition.Begin(mNormalBackground.gameObject, 1612f, GPPBCDLHJMC).onFinished = delegate
		{
			if (LOOAGDCIEIB)
			{
				TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
				TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
			}
			TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
			TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
			TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
			TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
			{
				TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
			};
		};
		TweenPosition.Begin(mCompletedBackground.gameObject, 878f, FEFLNBHLEDI).onFinished = MHOPIJIJOMN;
		TweenAlpha.Begin(mScullSprite.gameObject, 728f, 134f).onFinished = delegate
		{
			UISprite[] array = mProgressArrows;
			foreach (UISprite uISprite in array)
			{
				TweenColor.Begin(uISprite.gameObject, 0.2f, Color.black.ReplaceA(0.1f));
			}
			TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 0f).onFinished = delegate
			{
				TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
			};
		};
		TweenPosition.Begin(mScullSprite.gameObject, 1960f, GuiScreenSingle<DailyMissionScreen>.instance.OPAJFAGFILB(), useLocal: false);
	}

	public void DFGDKHDPFHH()
	{
		TweenAlpha.Begin(mAnimationSprite.gameObject, 1301f, 1230f, 1699f);
		mNormalPart.SetActive(value: true);
		mLockedPart.SetActive(value: true);
		mProgressPart.SetActive(value: false);
		LALJLMACNJO = false;
		BPHIDCOEOAG(ECEOFMAEOGE: true);
		TweenAlpha.Begin(mGlow1.gameObject, 1421f, 1258f);
		TweenAlpha.Begin(mGlow2.gameObject, 873f, 482f);
		TweenAlpha.Begin(mGlow2.gameObject, 960f, 320f);
		TweenAlpha.Begin(mNormalBackground.gameObject.gameObject, 391f, 656f);
		TweenAlpha.Begin(mScullSprite.gameObject, 1365f, 1584f);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 400f, 1908f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 949f, 573f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 993f, 1095f);
	}

	private void HNMOBBDDCLE(UITweener AKCKHOODNAI)
	{
		TweenPosition.Begin(mXPRewardPoints.gameObject, 1110f, mXPRewardPoints.transform.localPosition.ReplaceY(1636f)).onFinished = LDFMHJJEIAP;
	}

	public void NEEMNBFIAPI()
	{
		DFGDKHDPFHH();
		mButtonCollider.enabled = true;
		TweenAlpha.Begin(mGlow1.gameObject, 588f, 1590f).onFinished = POCDFDBJJOP;
	}

	private void CJDIEHOOPHG()
	{
		Vector3 vector = new Vector3(392f, 1556f, 1875f);
		TweenScale tweenScale = TweenScale.Begin(mAnimationObject, 1327f, vector, vector.MultiplyXY(1873f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mAnimationSprite.gameObject, 1703f, 440f, 783f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Once;
	}

	private void BFMNBNIMGMM(UITweener AKCKHOODNAI)
	{
		TweenPosition.Begin(mXPRewardPoints.gameObject, 1317f, mXPRewardPoints.transform.localPosition.ReplaceY(1195f), useLocal: false).onFinished = GIHPPCJNKLK;
	}

	public void AnimateCompleted()
	{
		LOMAFKIMCDC();
		mButtonCollider.enabled = DebugSettings.debugEnabled;
		if (LOOAGDCIEIB)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 1f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(0f)).onFinished = delegate
			{
				TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.1f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-20f));
			};
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.1f, 0f).onFinished = delegate
			{
				TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 1f);
				TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f), mWarbucksRewardAmount.transform.localPosition.ReplaceY(0f)).onFinished = delegate
				{
					TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.1f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-20f));
				};
			};
		}
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0.2f, 0f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0.2f, 0f);
		TweenPosition.Begin(mPlayButton, 0.1f, mPlayButton.transform.localPosition.AddY(30f)).onFinished = delegate
		{
			TweenPosition.Begin(mPlayButton, 0.1f, mPlayButton.transform.localPosition.ReplaceY(154f));
		};
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionCompleted);
		TweenScale.Begin(mScullPlusSprite.gameObject, 0.5f, IOCFIFJEEGF.MultiplyXY(0.6f));
		TweenScale.Begin(mSkullObject, 0.5f, Vector3.one, Vector3.one.MultiplyXY(2.5f)).onFinished = delegate
		{
			TweenPosition.Begin(mScullPlusSprite.gameObject, 0.2f, NHIMGLEKLIE.AddY(30f));
			TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 0f);
			TweenScale.Begin(mSkullObject, 0.6f, Vector3.one);
			TweenPosition.Begin(mScullSprite.gameObject, 0.2f, AKFOIFLDNGI).onFinished = delegate
			{
				TweenAlpha.Begin(mGlow1.gameObject, 0.6f, 0f);
				TweenAlpha.Begin(mGlow2.gameObject, 0.6f, 0f);
				TweenPosition.Begin(mNormalBackground.gameObject, 0.1f, GPPBCDLHJMC).onFinished = delegate
				{
					if (LOOAGDCIEIB)
					{
						TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
						TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
						TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
						TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
					}
					TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
					TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
					TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
					TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
					{
						TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
					};
				};
				TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI).onFinished = delegate
				{
					if (LOOAGDCIEIB)
					{
						TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 1f);
						TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f), mXPRewardLabel.transform.localPosition.ReplaceY(0f)).onFinished = delegate
						{
							TweenPosition.Begin(mXPRewardLabel.gameObject, 0.1f, mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
						};
						TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.1f, 0f).onFinished = delegate
						{
							TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 1f);
							TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f), mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = delegate
							{
								TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
								{
									TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
									{
										TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
										TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
										TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
										TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
										TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
										{
											if (!LevelManager.instance.isLevelUp)
											{
												ContinueCompletedAnimation();
											}
										};
									};
								};
							};
						};
					}
					TweenScale.Begin(mCompletedCheck.gameObject, 0.2f, BFLOBIJCMHE.MultiplyXY(3f), BFLOBIJCMHE);
					TweenAlpha.Begin(mCompletedCheck.gameObject, 0.2f, 1f);
					TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI.AddY(30f), FEFLNBHLEDI);
					TweenAlpha.Begin(mCompletedBackground.gameObject, 0.2f, 1f);
				};
				TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f).onFinished = delegate
				{
					UISprite[] array = mProgressArrows;
					foreach (UISprite uISprite in array)
					{
						TweenColor.Begin(uISprite.gameObject, 0.2f, Color.black.ReplaceA(0.1f));
					}
					TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 0f).onFinished = delegate
					{
						TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
					};
				};
				TweenPosition.Begin(mScullSprite.gameObject, 0.4f, GuiScreenSingle<DailyMissionScreen>.instance.positionToAnimatePointsGain, useLocal: false);
			};
		};
	}

	private void AEPMGKMPOFH(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 319f)
		{
			PAENPHMEMGC = 384f;
		}
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num = 568f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 1215f * (28f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void PNHHCHPMPCA(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mNumber.gameObject, 839f, MHIAJFBLHEC, useLocal: false);
	}

	[CompilerGenerated]
	private void FOIJNMHANBO(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
	}

	[CompilerGenerated]
	private void GOAGFOMOJKD(UITweener CILHMLFIJJG)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 1f);
		TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f), mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = delegate
		{
			TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
			{
				TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
				{
					TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
					TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
					TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
					{
						if (!LevelManager.instance.isLevelUp)
						{
							ContinueCompletedAnimation();
						}
					};
				};
			};
		};
	}

	private void BPHIDCOEOAG(bool ECEOFMAEOGE)
	{
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(1989f));
			}
		}
	}

	private void AKHNNNLPHGC()
	{
		mPlayButton.SetActive(value: false);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 252f, 1787f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1566f, 464f);
		TweenPosition.Begin(mNumber.gameObject, 1045f, MHIAJFBLHEC);
		TweenPosition.Begin(mNormalBackground.gameObject, 650f, GPPBCDLHJMC, useLocal: false);
		TweenScale.Begin(mNormalBackground.gameObject, 219f, IGHJLCNFMPG);
		TweenAlpha.Begin(mNormalBackground.gameObject, 216f, 1299f);
		TweenScale.Begin(mSkullObject, 738f, Vector3.one);
		TweenPosition.Begin(mScullPlusSprite.gameObject, 1603f, NHIMGLEKLIE);
		TweenScale.Begin(mScullPlusSprite.gameObject, 1974f, IOCFIFJEEGF);
		TweenPosition.Begin(mScullSprite.gameObject, 873f, AKFOIFLDNGI);
		TweenScale.Begin(mScullSprite.gameObject, 1117f, HBEDCLGBJOL);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 205f, 1250f);
		TweenAlpha.Begin(mScullSprite.gameObject, 1467f, 1908f);
		TweenAlpha.Begin(mGlow1.gameObject, 848f, 835f);
		TweenAlpha.Begin(mGlow2.gameObject, 1145f, 1951f);
		TweenPosition.Begin(mCompletedBackground.gameObject, 1154f, FEFLNBHLEDI, useLocal: false);
		TweenAlpha.Begin(mCompletedBackground.gameObject, 1614f, 1242f);
		TweenAlpha.Begin(mCompletedCheck.gameObject, 1482f, 1407f);
		TweenAlpha.Begin(mCompletedLabel.gameObject, 70f, AGOCILPHNOB);
		if (LOOAGDCIEIB)
		{
			mRewardsObject.SetActive(value: true);
			TweenAlpha.Begin(mXPRewardLabel.gameObject, 1980f, 1911f);
			TweenAlpha.Begin(mXPRewardPoints.gameObject, 954f, 1107f);
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1368f, 536f);
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 1712f, 1822f);
		}
		TweenScale.Begin(mLockedLock.gameObject, 1076f, EJELJJMLBGE);
		TweenAlpha.Begin(mLockedLock.gameObject, 907f, 1610f);
		TweenScale.Begin(mLockedBackground.gameObject, 1935f, PDEBIAGFDAL);
		TweenAlpha.Begin(mLockedBackground.gameObject, 824f, 1341f);
		TweenAlpha.Begin(mLockedSkull.gameObject, 93f, 891f);
		TweenAlpha.Begin(mLockedLabel.gameObject, 1827f, 46f);
	}

	private void NBEJFDMKFDB()
	{
		NHIMGLEKLIE = mScullPlusSprite.transform.localPosition;
		IOCFIFJEEGF = mScullPlusSprite.transform.localScale;
		AKFOIFLDNGI = mScullSprite.transform.localPosition;
		HBEDCLGBJOL = mScullSprite.transform.localScale;
		GPPBCDLHJMC = mNormalBackground.transform.localPosition;
		IGHJLCNFMPG = mNormalBackground.transform.localScale;
		FEFLNBHLEDI = mCompletedBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		BFLOBIJCMHE = mCompletedCheck.transform.localScale;
		EJELJJMLBGE = mLockedLock.transform.localScale;
		PDEBIAGFDAL = mLockedBackground.transform.localScale;
	}

	[CompilerGenerated]
	private void GLLIOOIJNAO(UITweener BHBCEPBDLOB)
	{
		if (LOOAGDCIEIB)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
			TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
		}
		TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
		TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
		TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
		TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
		{
			TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
		};
	}

	public void MPAOKAEBFGN()
	{
		GuiScreenSingle<DailyMissionScreen>.instance.JLDOMBAKNAN();
		if (DPGPOMCNMNF != null && DPGPOMCNMNF.isSolo && DPGPOMCNMNF.number == 0)
		{
			GuiScreenSingle<DailyMissionScreen>.instance.CEIPCDDFMJB();
		}
	}

	public void EPEOKAODOJA()
	{
		BEKHAHCBGLF();
		mButtonCollider.enabled = DebugSettings.debugEnabled;
		if (LOOAGDCIEIB)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1954f, 468f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 781f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(1589f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(1813f)).onFinished = CIFMAANPMAN;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 435f, 722f).onFinished = EMCGNAMEBKB;
		}
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1865f, 669f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 846f, 1507f);
		TweenPosition.Begin(mPlayButton, 1430f, mPlayButton.transform.localPosition.AddY(1051f)).onFinished = ODBAILNEPFI;
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-68), 447f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 855f, IOCFIFJEEGF.MultiplyXY(1832f));
		TweenScale.Begin(mSkullObject, 1804f, Vector3.one, Vector3.one.MultiplyXY(287f)).onFinished = HCHGALBHEKP;
	}

	private void JEBPBODCNMA(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mGlow1.gameObject, 1261f, 366f);
		TweenAlpha.Begin(mGlow2.gameObject, 607f, 1569f);
		TweenPosition.Begin(mNormalBackground.gameObject, 1035f, GPPBCDLHJMC).onFinished = delegate
		{
			if (LOOAGDCIEIB)
			{
				TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
				TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
			}
			TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
			TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
			TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
			TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
			{
				TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
			};
		};
		TweenPosition.Begin(mCompletedBackground.gameObject, 1682f, FEFLNBHLEDI).onFinished = delegate
		{
			if (LOOAGDCIEIB)
			{
				TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 1f);
				TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f), mXPRewardLabel.transform.localPosition.ReplaceY(0f)).onFinished = delegate
				{
					TweenPosition.Begin(mXPRewardLabel.gameObject, 0.1f, mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
				};
				TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.1f, 0f).onFinished = delegate
				{
					TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 1f);
					TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f), mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = delegate
					{
						TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
						{
							TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
							{
								TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
								TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
								TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
								TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
								TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
								{
									if (!LevelManager.instance.isLevelUp)
									{
										ContinueCompletedAnimation();
									}
								};
							};
						};
					};
				};
			}
			TweenScale.Begin(mCompletedCheck.gameObject, 0.2f, BFLOBIJCMHE.MultiplyXY(3f), BFLOBIJCMHE);
			TweenAlpha.Begin(mCompletedCheck.gameObject, 0.2f, 1f);
			TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI.AddY(30f), FEFLNBHLEDI);
			TweenAlpha.Begin(mCompletedBackground.gameObject, 0.2f, 1f);
		};
		TweenAlpha.Begin(mScullSprite.gameObject, 351f, 154f).onFinished = HBIIHLAAJFK;
		TweenPosition.Begin(mScullSprite.gameObject, 1843f, GuiScreenSingle<DailyMissionScreen>.instance.NGCBJNLCGAF());
	}

	[CompilerGenerated]
	private void FJIFJJDJEFB(UITweener BDEOMPEJELN)
	{
		TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.1f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-20f));
	}

	private void PELFDKCLFJJ()
	{
		NHIMGLEKLIE = mScullPlusSprite.transform.localPosition;
		IOCFIFJEEGF = mScullPlusSprite.transform.localScale;
		AKFOIFLDNGI = mScullSprite.transform.localPosition;
		HBEDCLGBJOL = mScullSprite.transform.localScale;
		GPPBCDLHJMC = mNormalBackground.transform.localPosition;
		IGHJLCNFMPG = mNormalBackground.transform.localScale;
		FEFLNBHLEDI = mCompletedBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		BFLOBIJCMHE = mCompletedCheck.transform.localScale;
		EJELJJMLBGE = mLockedLock.transform.localScale;
		PDEBIAGFDAL = mLockedBackground.transform.localScale;
	}

	private void DOINHAEFDNB()
	{
		Vector3 vector = new Vector3(1f, 1f, 1f);
		TweenScale tweenScale = TweenScale.Begin(mAnimationObject, 0.8f, vector, vector.MultiplyXY(2f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mAnimationSprite.gameObject, 0.8f, 0.4f, 0f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	private void MBCHNOCPGDB()
	{
		Vector3 vector = new Vector3(475f, 690f, 760f);
		TweenScale tweenScale = TweenScale.Begin(mAnimationObject, 562f, vector, vector.MultiplyXY(223f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mAnimationSprite.gameObject, 1613f, 1139f, 1035f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	public void JLEPIFMODPO()
	{
		TweenAlpha.Begin(mAnimationSprite.gameObject, 1542f, 1162f, 1683f);
		mNormalPart.SetActive(value: false);
		mLockedPart.SetActive(value: true);
		mProgressPart.SetActive(value: true);
		LALJLMACNJO = false;
		LOEEEMPEGJM(ECEOFMAEOGE: true);
		TweenAlpha.Begin(mGlow1.gameObject, 38f, 49f);
		TweenAlpha.Begin(mGlow2.gameObject, 612f, 1024f);
		TweenAlpha.Begin(mGlow2.gameObject, 1313f, 1423f);
		TweenAlpha.Begin(mNormalBackground.gameObject.gameObject, 1421f, 1400f);
		TweenAlpha.Begin(mScullSprite.gameObject, 1284f, 1458f);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 300f, 233f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1237f, 480f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 480f, 467f);
	}

	[CompilerGenerated]
	private void HGGKLLHHPHN(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mGlow1.gameObject, 0.6f, 0f);
		TweenAlpha.Begin(mGlow2.gameObject, 0.6f, 0f);
		TweenPosition.Begin(mNormalBackground.gameObject, 0.1f, GPPBCDLHJMC).onFinished = delegate
		{
			if (LOOAGDCIEIB)
			{
				TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
				TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
			}
			TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
			TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
			TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
			TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
			{
				TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
			};
		};
		TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI).onFinished = delegate
		{
			if (LOOAGDCIEIB)
			{
				TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 1f);
				TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f), mXPRewardLabel.transform.localPosition.ReplaceY(0f)).onFinished = delegate
				{
					TweenPosition.Begin(mXPRewardLabel.gameObject, 0.1f, mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
				};
				TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.1f, 0f).onFinished = delegate
				{
					TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 1f);
					TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f), mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = delegate
					{
						TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
						{
							TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
							{
								TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
								TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
								TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
								TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
								TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
								{
									if (!LevelManager.instance.isLevelUp)
									{
										ContinueCompletedAnimation();
									}
								};
							};
						};
					};
				};
			}
			TweenScale.Begin(mCompletedCheck.gameObject, 0.2f, BFLOBIJCMHE.MultiplyXY(3f), BFLOBIJCMHE);
			TweenAlpha.Begin(mCompletedCheck.gameObject, 0.2f, 1f);
			TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI.AddY(30f), FEFLNBHLEDI);
			TweenAlpha.Begin(mCompletedBackground.gameObject, 0.2f, 1f);
		};
		TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f).onFinished = delegate
		{
			UISprite[] array = mProgressArrows;
			foreach (UISprite uISprite in array)
			{
				TweenColor.Begin(uISprite.gameObject, 0.2f, Color.black.ReplaceA(0.1f));
			}
			TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 0f).onFinished = delegate
			{
				TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
			};
		};
		TweenPosition.Begin(mScullSprite.gameObject, 0.4f, GuiScreenSingle<DailyMissionScreen>.instance.positionToAnimatePointsGain, useLocal: false);
	}

	private void LFCNDANDMLF(GameObject KHAHPAKDIKE)
	{
		if (DPGPOMCNMNF != null)
		{
			GuiElementSingle<DailyMissionDialog>.instance.EJDJFNDOFOK(DPGPOMCNMNF);
			DailyMissionsManager.instance.APFKBBHHAAG(DPGPOMCNMNF);
		}
	}

	private void CBOJIGJBHCB()
	{
		NHIMGLEKLIE = mScullPlusSprite.transform.localPosition;
		IOCFIFJEEGF = mScullPlusSprite.transform.localScale;
		AKFOIFLDNGI = mScullSprite.transform.localPosition;
		HBEDCLGBJOL = mScullSprite.transform.localScale;
		GPPBCDLHJMC = mNormalBackground.transform.localPosition;
		IGHJLCNFMPG = mNormalBackground.transform.localScale;
		FEFLNBHLEDI = mCompletedBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		BFLOBIJCMHE = mCompletedCheck.transform.localScale;
		EJELJJMLBGE = mLockedLock.transform.localScale;
		PDEBIAGFDAL = mLockedBackground.transform.localScale;
	}

	private void MEAGKLAOJIH(UITweener AKCKHOODNAI)
	{
		TweenPosition.Begin(mXPRewardPoints.gameObject, 1642f, mXPRewardPoints.transform.localPosition.ReplaceY(1836f), useLocal: false).onFinished = delegate
		{
			TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
				TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
				TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
				{
					if (!LevelManager.instance.isLevelUp)
					{
						ContinueCompletedAnimation();
					}
				};
			};
		};
	}

	[CompilerGenerated]
	private void NAPPKLJMMCM(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mGlow1.gameObject, 0.6f, 1f);
		TweenAlpha.Begin(mGlow2.gameObject, 0.6f, 1f).onFinished = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StarGained);
			if (LOOAGDCIEIB)
			{
				DOINHAEFDNB();
			}
			TweenAlpha.Begin(mLockedLabel.gameObject, 0.3f, 0f);
			TweenAlpha.Begin(mLockedLock.gameObject, 0.3f, 0f);
			TweenScale.Begin(mLockedLock.gameObject, 0.3f, EJELJJMLBGE.MultiplyXY(2f));
			TweenAlpha.Begin(mLockedSkull.gameObject, 0.3f, 0f);
			TweenAlpha.Begin(mNormalBackground.gameObject, 0.3f, 1f);
			TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0.3f, 1f);
			TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0.3f, 1f);
			TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.AddY(30f));
			TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG.MultiplyXY(2f), IGHJLCNFMPG.MultiplyXY(0.8f)).onFinished = delegate
			{
				TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.ReplaceY(154f));
				UISprite[] array = mProgressArrows;
				foreach (UISprite uISprite in array)
				{
					TweenColor.Begin(uISprite.gameObject, 0.5f, Color.white);
				}
				TweenAlpha.Begin(mLockedBackground.gameObject, 0.6f, 0f);
				TweenScale.Begin(mLockedBackground.gameObject, 0.5f, PDEBIAGFDAL.MultiplyXY(2f));
				TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG);
				TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f);
				TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL.MultiplyXY(1.5f), HBEDCLGBJOL.MultiplyXY(0.8f)).onFinished = delegate
				{
					TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL);
					TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 1f);
					TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF.MultiplyXY(1.5f), IOCFIFJEEGF.MultiplyXY(0.8f)).onFinished = delegate
					{
						TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
					};
				};
			};
		};
	}

	private void LOEEEMPEGJM(bool ECEOFMAEOGE)
	{
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(1871f));
			}
		}
	}

	private void IKBNBMMMKAN(UITweener DAECHDDDMJN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-99), 667f);
		if (GPDDCEJAJDA())
		{
			MBCHNOCPGDB();
		}
		TweenAlpha.Begin(mLockedLabel.gameObject, 372f, 1028f);
		TweenAlpha.Begin(mLockedLock.gameObject, 1233f, 1437f);
		TweenScale.Begin(mLockedLock.gameObject, 1360f, EJELJJMLBGE.MultiplyXY(955f));
		TweenAlpha.Begin(mLockedSkull.gameObject, 1955f, 1548f);
		TweenAlpha.Begin(mNormalBackground.gameObject, 1388f, 802f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1725f, 906f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1487f, 1161f);
		TweenPosition.Begin(mPlayButton, 312f, mPlayButton.transform.localPosition.AddY(1390f));
		TweenScale.Begin(mNormalBackground.gameObject, 1225f, IGHJLCNFMPG.MultiplyXY(1096f), IGHJLCNFMPG.MultiplyXY(767f)).onFinished = delegate
		{
			TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.ReplaceY(154f));
			UISprite[] array = mProgressArrows;
			foreach (UISprite uISprite in array)
			{
				TweenColor.Begin(uISprite.gameObject, 0.5f, Color.white);
			}
			TweenAlpha.Begin(mLockedBackground.gameObject, 0.6f, 0f);
			TweenScale.Begin(mLockedBackground.gameObject, 0.5f, PDEBIAGFDAL.MultiplyXY(2f));
			TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG);
			TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f);
			TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL.MultiplyXY(1.5f), HBEDCLGBJOL.MultiplyXY(0.8f)).onFinished = delegate
			{
				TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL);
				TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 1f);
				TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF.MultiplyXY(1.5f), IOCFIFJEEGF.MultiplyXY(0.8f)).onFinished = delegate
				{
					TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
				};
			};
		};
	}

	private void PDHNLCFLEDG(UITweener NPAJIAIILLL)
	{
		TweenScale.Begin(mScullPlusSprite.gameObject, 152f, IOCFIFJEEGF);
	}

	public void InitGuiValues(DailyMission EHIPMLOMMIG, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		DPGPOMCNMNF = EHIPMLOMMIG;
		AFIAPIFAAFC();
		mButtonCollider.enabled = GIAFDDAKALM || DebugSettings.debugEnabled;
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(DPGPOMCNMNF.number);
		mNormalPart.SetActive(GIAFDDAKALM);
		mCompletedPart.SetActive(ECEOFMAEOGE);
		mLockedPart.gameObject.SetActive(!ECEOFMAEOGE && !GIAFDDAKALM);
		if (GIAFDDAKALM && !EHIPMLOMMIG.isCoop)
		{
			DOINHAEFDNB();
		}
		else if (GIAFDDAKALM)
		{
			mAnimationObject.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 0f;
		CEAPNHFPKHM(1f);
		ADCCFCDFNGI(ECEOFMAEOGE);
	}

	private void ENEAFIFPLGJ(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 761f, 847f);
		TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 1504f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(610f), mWarbucksRewardAmount.transform.localPosition.ReplaceY(313f)).onFinished = EHHBPGHJOHP;
	}

	private void Update()
	{
		if (LALJLMACNJO && mSpeed > 0f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			CEAPNHFPKHM(num / mSpeed);
		}
	}

	private void DBOPAHECCPP(UITweener KDMCDGPHBCF)
	{
		TweenScale.Begin(mScullSprite.gameObject, 1966f, HBEDCLGBJOL);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 660f, 1002f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 621f, IOCFIFJEEGF.MultiplyXY(706f), IOCFIFJEEGF.MultiplyXY(1288f)).onFinished = delegate
		{
			TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
		};
	}

	[CompilerGenerated]
	private void BNKCANCJNON(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mXPRewardLabel.gameObject, 0.1f, mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
	}

	public void HGANAKEFBOH()
	{
		CPIFKDEJMGK();
		mButtonCollider.enabled = DebugSettings.debugEnabled;
		if (LOOAGDCIEIB)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 889f, 1781f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 1522f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(1152f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(1008f), useLocal: false).onFinished = CIFMAANPMAN;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 118f, 101f).onFinished = ENEAFIFPLGJ;
		}
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1218f, 1716f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1857f, 1884f);
		TweenPosition.Begin(mPlayButton, 177f, mPlayButton.transform.localPosition.AddY(165f)).onFinished = delegate
		{
			TweenPosition.Begin(mPlayButton, 0.1f, mPlayButton.transform.localPosition.ReplaceY(154f));
		};
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-99), 672f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 1456f, IOCFIFJEEGF.MultiplyXY(1271f));
		TweenScale.Begin(mSkullObject, 76f, Vector3.one, Vector3.one.MultiplyXY(1416f)).onFinished = MCJMGEFKFOC;
	}

	private void GLCIHIGBHPK(UITweener DAECHDDDMJN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-2), 22f);
		if (LOOAGDCIEIB)
		{
			HLCMDJHGBPD();
		}
		TweenAlpha.Begin(mLockedLabel.gameObject, 1750f, 1470f);
		TweenAlpha.Begin(mLockedLock.gameObject, 1934f, 834f);
		TweenScale.Begin(mLockedLock.gameObject, 987f, EJELJJMLBGE.MultiplyXY(1468f));
		TweenAlpha.Begin(mLockedSkull.gameObject, 1869f, 813f);
		TweenAlpha.Begin(mNormalBackground.gameObject, 778f, 196f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1637f, 1565f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 92f, 270f);
		TweenPosition.Begin(mPlayButton, 329f, mPlayButton.transform.localPosition.AddY(286f), useLocal: false);
		TweenScale.Begin(mNormalBackground.gameObject, 228f, IGHJLCNFMPG.MultiplyXY(1106f), IGHJLCNFMPG.MultiplyXY(1587f)).onFinished = BNLDOFKKEFL;
	}

	public void AnimateUnlocked()
	{
		PrepareForAnimationUnlock();
		mButtonCollider.enabled = true;
		TweenAlpha.Begin(mGlow1.gameObject, 0.5f, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(mGlow1.gameObject, 0.6f, 1f);
			TweenAlpha.Begin(mGlow2.gameObject, 0.6f, 1f).onFinished = delegate
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StarGained);
				if (LOOAGDCIEIB)
				{
					DOINHAEFDNB();
				}
				TweenAlpha.Begin(mLockedLabel.gameObject, 0.3f, 0f);
				TweenAlpha.Begin(mLockedLock.gameObject, 0.3f, 0f);
				TweenScale.Begin(mLockedLock.gameObject, 0.3f, EJELJJMLBGE.MultiplyXY(2f));
				TweenAlpha.Begin(mLockedSkull.gameObject, 0.3f, 0f);
				TweenAlpha.Begin(mNormalBackground.gameObject, 0.3f, 1f);
				TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0.3f, 1f);
				TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0.3f, 1f);
				TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.AddY(30f));
				TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG.MultiplyXY(2f), IGHJLCNFMPG.MultiplyXY(0.8f)).onFinished = delegate
				{
					TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.ReplaceY(154f));
					UISprite[] array = mProgressArrows;
					foreach (UISprite uISprite in array)
					{
						TweenColor.Begin(uISprite.gameObject, 0.5f, Color.white);
					}
					TweenAlpha.Begin(mLockedBackground.gameObject, 0.6f, 0f);
					TweenScale.Begin(mLockedBackground.gameObject, 0.5f, PDEBIAGFDAL.MultiplyXY(2f));
					TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG);
					TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f);
					TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL.MultiplyXY(1.5f), HBEDCLGBJOL.MultiplyXY(0.8f)).onFinished = delegate
					{
						TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL);
						TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 1f);
						TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF.MultiplyXY(1.5f), IOCFIFJEEGF.MultiplyXY(0.8f)).onFinished = delegate
						{
							TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
						};
					};
				};
			};
		};
	}

	private void CEAPNHFPKHM(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 0f)
		{
			PAENPHMEMGC = 1f;
		}
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num = 40f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 40f * (-1f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void KHIAMGKAPNH(bool ECEOFMAEOGE)
	{
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(66f));
			}
		}
	}

	public void PrepareForAnimationUnlock()
	{
		TweenAlpha.Begin(mAnimationSprite.gameObject, 0.8f, 0f, 0f);
		mNormalPart.SetActive(value: true);
		mLockedPart.SetActive(value: true);
		mProgressPart.SetActive(value: true);
		LALJLMACNJO = true;
		ADCCFCDFNGI(ECEOFMAEOGE: true);
		TweenAlpha.Begin(mGlow1.gameObject, 0f, 0f);
		TweenAlpha.Begin(mGlow2.gameObject, 0f, 0f);
		TweenAlpha.Begin(mGlow2.gameObject, 0f, 0f);
		TweenAlpha.Begin(mNormalBackground.gameObject.gameObject, 0f, 0f);
		TweenAlpha.Begin(mScullSprite.gameObject, 0f, 0f);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 0f, 0f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0f, 0f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0f, 0f);
	}

	private void CPIFKDEJMGK()
	{
		if (GPDDCEJAJDA())
		{
			foreach (CDACJEGCGLB reward in DPGPOMCNMNF.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 1363f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 169f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(477f - num / 364f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(138f - num2 / 460f);
			mXPRewardObject.repositionNow = false;
			mWarbucksRewardObject.repositionNow = false;
		}
		mAnimationObject.SetActive(value: false);
		mProgressPart.SetActive(value: true);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = false;
		mNormalPart.SetActive(value: false);
		mCompletedPart.SetActive(value: false);
		TweenAlpha.Begin(mDoneProgress.gameObject, 1664f, 159f);
		TweenAlpha.Begin(mCompletedBackground.gameObject, 1633f, 397f);
		TweenAlpha.Begin(mCompletedCheck.gameObject, 1873f, 1172f);
		TweenAlpha.Begin(mCompletedLabel.gameObject, 26f, 1252f);
		ADCCFCDFNGI(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	private void LAPNDKFIMKK(UITweener AKCKHOODNAI)
	{
		TweenPosition.Begin(mXPRewardPoints.gameObject, 113f, mXPRewardPoints.transform.localPosition.ReplaceY(1377f)).onFinished = HILKOBFABLE;
	}

	private void PLNNBCCCAOJ()
	{
		Vector3 vector = new Vector3(1048f, 233f, 478f);
		TweenScale tweenScale = TweenScale.Begin(mAnimationObject, 31f, vector, vector.MultiplyXY(1654f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mAnimationSprite.gameObject, 1738f, 721f, 1429f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Once;
	}

	public void InitControls(float CEHFMMJHCKC)
	{
		AGOCILPHNOB = mCompletedLabel.alpha;
		float num = 114f;
		float num2 = CEHFMMJHCKC - num / 2f;
		float num3 = CEHFMMJHCKC - num + 40f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num4 = 40f * (float)i;
			mProgressArrows[i].gameObject.SetActive(num4 <= num3);
		}
		CEAPNHFPKHM(0f, KAKIMEJCEFA: true);
		EECEGLNCGNG();
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNFPPBDAHFK));
	}

	private void IGPHNEKIFKK(UITweener NPAJIAIILLL)
	{
		TweenScale.Begin(mScullPlusSprite.gameObject, 447f, IOCFIFJEEGF);
	}

	private void IENFLEMOIOD(bool ECEOFMAEOGE)
	{
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(467f));
			}
		}
	}

	public void IDOHCKKEGNE()
	{
		TweenAlpha.Begin(mAnimationSprite.gameObject, 943f, 1145f, 737f);
		mNormalPart.SetActive(value: false);
		mLockedPart.SetActive(value: true);
		mProgressPart.SetActive(value: false);
		LALJLMACNJO = false;
		IENFLEMOIOD(ECEOFMAEOGE: false);
		TweenAlpha.Begin(mGlow1.gameObject, 1844f, 935f);
		TweenAlpha.Begin(mGlow2.gameObject, 360f, 1718f);
		TweenAlpha.Begin(mGlow2.gameObject, 1156f, 631f);
		TweenAlpha.Begin(mNormalBackground.gameObject.gameObject, 836f, 39f);
		TweenAlpha.Begin(mScullSprite.gameObject, 883f, 1624f);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 1195f, 1408f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 380f, 1775f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1265f, 1032f);
	}

	private void AGCCKCBCFMM(UITweener DAECHDDDMJN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)118, 1002f);
		if (LOOAGDCIEIB)
		{
			PLNNBCCCAOJ();
		}
		TweenAlpha.Begin(mLockedLabel.gameObject, 1718f, 680f);
		TweenAlpha.Begin(mLockedLock.gameObject, 654f, 911f);
		TweenScale.Begin(mLockedLock.gameObject, 443f, EJELJJMLBGE.MultiplyXY(252f));
		TweenAlpha.Begin(mLockedSkull.gameObject, 366f, 1414f);
		TweenAlpha.Begin(mNormalBackground.gameObject, 401f, 1285f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1681f, 578f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1245f, 1326f);
		TweenPosition.Begin(mPlayButton, 315f, mPlayButton.transform.localPosition.AddY(343f), useLocal: false);
		TweenScale.Begin(mNormalBackground.gameObject, 1994f, IGHJLCNFMPG.MultiplyXY(1829f), IGHJLCNFMPG.MultiplyXY(1110f)).onFinished = BNLDOFKKEFL;
	}

	private void LBIFNPLHGBA(UITweener AEEBLJKPGMO)
	{
		UISprite[] array = mProgressArrows;
		for (int i = 1; i < array.Length; i += 0)
		{
			UISprite uISprite = array[i];
			TweenColor.Begin(uISprite.gameObject, 1303f, Color.black.ReplaceA(1307f));
		}
		TweenAlpha.Begin(mScullSprite.gameObject, 1989f, 1870f).onFinished = ANNMODBOFOD;
	}

	private void FLDCHPBPKND()
	{
		if (LALJLMACNJO && mSpeed > 1190f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			IGGFLDFBGEN(num / mSpeed);
		}
	}

	[CompilerGenerated]
	private void KAKCHHBGBDC(UITweener BHBCEPBDLOB)
	{
		if (LOOAGDCIEIB)
		{
			TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 1f);
			TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f), mXPRewardLabel.transform.localPosition.ReplaceY(0f)).onFinished = delegate
			{
				TweenPosition.Begin(mXPRewardLabel.gameObject, 0.1f, mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
			};
			TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.1f, 0f).onFinished = delegate
			{
				TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 1f);
				TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f), mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = delegate
				{
					TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
					{
						TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
						{
							TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
							TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
							TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
							TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
							TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
							{
								if (!LevelManager.instance.isLevelUp)
								{
									ContinueCompletedAnimation();
								}
							};
						};
					};
				};
			};
		}
		TweenScale.Begin(mCompletedCheck.gameObject, 0.2f, BFLOBIJCMHE.MultiplyXY(3f), BFLOBIJCMHE);
		TweenAlpha.Begin(mCompletedCheck.gameObject, 0.2f, 1f);
		TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI.AddY(30f), FEFLNBHLEDI);
		TweenAlpha.Begin(mCompletedBackground.gameObject, 0.2f, 1f);
	}

	private void EHHBPGHJOHP(UITweener BDEOMPEJELN)
	{
		TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 752f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(272f));
	}

	private void FNNILHDCBFA(UITweener CILHMLFIJJG)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 146f, 799f);
		TweenPosition.Begin(mXPRewardPoints.gameObject, 1047f, mXPRewardPoints.transform.localPosition.ReplaceY(641f), mXPRewardPoints.transform.localPosition.ReplaceY(999f)).onFinished = LAPNDKFIMKK;
	}

	private void GLPHKMPNOMC()
	{
		NHIMGLEKLIE = mScullPlusSprite.transform.localPosition;
		IOCFIFJEEGF = mScullPlusSprite.transform.localScale;
		AKFOIFLDNGI = mScullSprite.transform.localPosition;
		HBEDCLGBJOL = mScullSprite.transform.localScale;
		GPPBCDLHJMC = mNormalBackground.transform.localPosition;
		IGHJLCNFMPG = mNormalBackground.transform.localScale;
		FEFLNBHLEDI = mCompletedBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		BFLOBIJCMHE = mCompletedCheck.transform.localScale;
		EJELJJMLBGE = mLockedLock.transform.localScale;
		PDEBIAGFDAL = mLockedBackground.transform.localScale;
	}

	private void ALPCLOLJBGJ(UITweener KDMCDGPHBCF)
	{
		TweenScale.Begin(mScullSprite.gameObject, 1108f, HBEDCLGBJOL);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 936f, 36f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 156f, IOCFIFJEEGF.MultiplyXY(854f), IOCFIFJEEGF.MultiplyXY(1980f)).onFinished = IGPHNEKIFKK;
	}

	private void CIFMAANPMAN(UITweener BDEOMPEJELN)
	{
		TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 1993f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(1649f));
	}

	private void BPOCEIABCPP(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mXPRewardLabel.gameObject, 876f, mXPRewardLabel.transform.localPosition.ReplaceY(764f));
	}

	public void NKCHCMPOBGD(DailyMission EHIPMLOMMIG, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		DPGPOMCNMNF = EHIPMLOMMIG;
		AKHNNNLPHGC();
		mButtonCollider.enabled = !GIAFDDAKALM && DebugSettings.debugEnabled;
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(DPGPOMCNMNF.number);
		mNormalPart.SetActive(GIAFDDAKALM);
		mCompletedPart.SetActive(ECEOFMAEOGE);
		mLockedPart.gameObject.SetActive(!ECEOFMAEOGE && GIAFDDAKALM);
		if (GIAFDDAKALM && !EHIPMLOMMIG.isCoop)
		{
			HLCMDJHGBPD();
		}
		else if (GIAFDDAKALM)
		{
			mAnimationObject.transform.localScale = new Vector3(436f, 1134f, 1544f);
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 707f;
		IGGFLDFBGEN(43f, KAKIMEJCEFA: true);
		KHIAMGKAPNH(ECEOFMAEOGE);
	}

	private void MAICENANBPO(UITweener NPAJIAIILLL)
	{
		TweenScale.Begin(mScullPlusSprite.gameObject, 78f, IOCFIFJEEGF);
	}

	[CompilerGenerated]
	private void LIFBMLOHIEN(UITweener KDMCDGPHBCF)
	{
		TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 1f);
		TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF.MultiplyXY(1.5f), IOCFIFJEEGF.MultiplyXY(0.8f)).onFinished = delegate
		{
			TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
		};
	}

	private void EMCGNAMEBKB(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 872f, 1335f);
		TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 958f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(766f), mWarbucksRewardAmount.transform.localPosition.ReplaceY(1240f), useLocal: false).onFinished = delegate
		{
			TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.1f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-20f));
		};
	}

	private void BAAFHFCELAG(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mNumber.gameObject, 86f, MHIAJFBLHEC);
	}

	private void CKGLHAGOEJG(UITweener AAHDNEKFJOA)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 1860f, 1323f).onFinished = MNEOBJLNDCN;
	}

	[CompilerGenerated]
	private void IDOJEEMGKDM(UITweener LPICCDPEOKA)
	{
		TweenPosition.Begin(mScullPlusSprite.gameObject, 0.2f, NHIMGLEKLIE.AddY(30f));
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 0f);
		TweenScale.Begin(mSkullObject, 0.6f, Vector3.one);
		TweenPosition.Begin(mScullSprite.gameObject, 0.2f, AKFOIFLDNGI).onFinished = delegate
		{
			TweenAlpha.Begin(mGlow1.gameObject, 0.6f, 0f);
			TweenAlpha.Begin(mGlow2.gameObject, 0.6f, 0f);
			TweenPosition.Begin(mNormalBackground.gameObject, 0.1f, GPPBCDLHJMC).onFinished = delegate
			{
				if (LOOAGDCIEIB)
				{
					TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
					TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
				}
				TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
				TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
				TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
				TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
				{
					TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
				};
			};
			TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI).onFinished = delegate
			{
				if (LOOAGDCIEIB)
				{
					TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 1f);
					TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f), mXPRewardLabel.transform.localPosition.ReplaceY(0f)).onFinished = delegate
					{
						TweenPosition.Begin(mXPRewardLabel.gameObject, 0.1f, mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
					};
					TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.1f, 0f).onFinished = delegate
					{
						TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 1f);
						TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f), mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = delegate
						{
							TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
							{
								TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
								{
									TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
									TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
									TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
									TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
									TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
									{
										if (!LevelManager.instance.isLevelUp)
										{
											ContinueCompletedAnimation();
										}
									};
								};
							};
						};
					};
				}
				TweenScale.Begin(mCompletedCheck.gameObject, 0.2f, BFLOBIJCMHE.MultiplyXY(3f), BFLOBIJCMHE);
				TweenAlpha.Begin(mCompletedCheck.gameObject, 0.2f, 1f);
				TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI.AddY(30f), FEFLNBHLEDI);
				TweenAlpha.Begin(mCompletedBackground.gameObject, 0.2f, 1f);
			};
			TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f).onFinished = delegate
			{
				UISprite[] array = mProgressArrows;
				foreach (UISprite uISprite in array)
				{
					TweenColor.Begin(uISprite.gameObject, 0.2f, Color.black.ReplaceA(0.1f));
				}
				TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 0f).onFinished = delegate
				{
					TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
				};
			};
			TweenPosition.Begin(mScullSprite.gameObject, 0.4f, GuiScreenSingle<DailyMissionScreen>.instance.positionToAnimatePointsGain, useLocal: false);
		};
	}

	private void BEKHAHCBGLF()
	{
		if (GPDDCEJAJDA())
		{
			foreach (CDACJEGCGLB reward in DPGPOMCNMNF.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: true);
			float num = 1575f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 868f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(953f - num / 580f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(153f - num2 / 465f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = true;
		}
		mAnimationObject.SetActive(value: true);
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = true;
		mNormalPart.SetActive(value: true);
		mCompletedPart.SetActive(value: false);
		TweenAlpha.Begin(mDoneProgress.gameObject, 1271f, 1009f);
		TweenAlpha.Begin(mCompletedBackground.gameObject, 752f, 1724f);
		TweenAlpha.Begin(mCompletedCheck.gameObject, 1476f, 226f);
		TweenAlpha.Begin(mCompletedLabel.gameObject, 434f, 37f);
		ADCCFCDFNGI(ECEOFMAEOGE: false);
		mNumber.color = Color.black;
	}

	[CompilerGenerated]
	private void DHHPMNKCBLN(UITweener MMMNJFHDJDC)
	{
		TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
		TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
		TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
		{
			if (!LevelManager.instance.isLevelUp)
			{
				ContinueCompletedAnimation();
			}
		};
	}

	public void PEIILMKDGBK(float CEHFMMJHCKC)
	{
		AGOCILPHNOB = mCompletedLabel.alpha;
		float num = 1078f;
		float num2 = CEHFMMJHCKC - num / 1844f;
		float num3 = CEHFMMJHCKC - num + 1672f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			float num4 = 1238f * (float)i;
			mProgressArrows[i].gameObject.SetActive(num4 <= num3);
		}
		EDMIHHBPOCE(1010f);
		NBEJFDMKFDB();
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNFPPBDAHFK));
	}

	[CompilerGenerated]
	private void NMMDGDAMHLG(UITweener DAECHDDDMJN)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StarGained);
		if (LOOAGDCIEIB)
		{
			DOINHAEFDNB();
		}
		TweenAlpha.Begin(mLockedLabel.gameObject, 0.3f, 0f);
		TweenAlpha.Begin(mLockedLock.gameObject, 0.3f, 0f);
		TweenScale.Begin(mLockedLock.gameObject, 0.3f, EJELJJMLBGE.MultiplyXY(2f));
		TweenAlpha.Begin(mLockedSkull.gameObject, 0.3f, 0f);
		TweenAlpha.Begin(mNormalBackground.gameObject, 0.3f, 1f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0.3f, 1f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0.3f, 1f);
		TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.AddY(30f));
		TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG.MultiplyXY(2f), IGHJLCNFMPG.MultiplyXY(0.8f)).onFinished = delegate
		{
			TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.ReplaceY(154f));
			UISprite[] array = mProgressArrows;
			foreach (UISprite uISprite in array)
			{
				TweenColor.Begin(uISprite.gameObject, 0.5f, Color.white);
			}
			TweenAlpha.Begin(mLockedBackground.gameObject, 0.6f, 0f);
			TweenScale.Begin(mLockedBackground.gameObject, 0.5f, PDEBIAGFDAL.MultiplyXY(2f));
			TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG);
			TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f);
			TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL.MultiplyXY(1.5f), HBEDCLGBJOL.MultiplyXY(0.8f)).onFinished = delegate
			{
				TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL);
				TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 1f);
				TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF.MultiplyXY(1.5f), IOCFIFJEEGF.MultiplyXY(0.8f)).onFinished = delegate
				{
					TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
				};
			};
		};
	}

	[SpecialName]
	private bool GPDDCEJAJDA()
	{
		return DPGPOMCNMNF == null || DPGPOMCNMNF.isCoop;
	}

	private void EEGNAKPEJFE(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1955f)
		{
			PAENPHMEMGC = 373f;
		}
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			float num = 1098f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 433f * (196f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void DICONCJGDEA(UITweener DAECHDDDMJN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-90), 573f);
		if (LOOAGDCIEIB)
		{
			CJDIEHOOPHG();
		}
		TweenAlpha.Begin(mLockedLabel.gameObject, 957f, 489f);
		TweenAlpha.Begin(mLockedLock.gameObject, 435f, 876f);
		TweenScale.Begin(mLockedLock.gameObject, 361f, EJELJJMLBGE.MultiplyXY(719f));
		TweenAlpha.Begin(mLockedSkull.gameObject, 1558f, 965f);
		TweenAlpha.Begin(mNormalBackground.gameObject, 1802f, 1507f);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 216f, 210f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 560f, 420f);
		TweenPosition.Begin(mPlayButton, 973f, mPlayButton.transform.localPosition.AddY(279f));
		TweenScale.Begin(mNormalBackground.gameObject, 1497f, IGHJLCNFMPG.MultiplyXY(1143f), IGHJLCNFMPG.MultiplyXY(160f)).onFinished = delegate
		{
			TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.ReplaceY(154f));
			UISprite[] array = mProgressArrows;
			foreach (UISprite uISprite in array)
			{
				TweenColor.Begin(uISprite.gameObject, 0.5f, Color.white);
			}
			TweenAlpha.Begin(mLockedBackground.gameObject, 0.6f, 0f);
			TweenScale.Begin(mLockedBackground.gameObject, 0.5f, PDEBIAGFDAL.MultiplyXY(2f));
			TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG);
			TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f);
			TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL.MultiplyXY(1.5f), HBEDCLGBJOL.MultiplyXY(0.8f)).onFinished = delegate
			{
				TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL);
				TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 1f);
				TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF.MultiplyXY(1.5f), IOCFIFJEEGF.MultiplyXY(0.8f)).onFinished = delegate
				{
					TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
				};
			};
		};
	}

	private void MCJMGEFKFOC(UITweener LPICCDPEOKA)
	{
		TweenPosition.Begin(mScullPlusSprite.gameObject, 644f, NHIMGLEKLIE.AddY(1228f));
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 1813f, 211f);
		TweenScale.Begin(mSkullObject, 1188f, Vector3.one);
		TweenPosition.Begin(mScullSprite.gameObject, 48f, AKFOIFLDNGI).onFinished = delegate
		{
			TweenAlpha.Begin(mGlow1.gameObject, 0.6f, 0f);
			TweenAlpha.Begin(mGlow2.gameObject, 0.6f, 0f);
			TweenPosition.Begin(mNormalBackground.gameObject, 0.1f, GPPBCDLHJMC).onFinished = delegate
			{
				if (LOOAGDCIEIB)
				{
					TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
					TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
				}
				TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
				TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
				TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
				TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
				{
					TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
				};
			};
			TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI).onFinished = delegate
			{
				if (LOOAGDCIEIB)
				{
					TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 1f);
					TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f), mXPRewardLabel.transform.localPosition.ReplaceY(0f)).onFinished = delegate
					{
						TweenPosition.Begin(mXPRewardLabel.gameObject, 0.1f, mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
					};
					TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.1f, 0f).onFinished = delegate
					{
						TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 1f);
						TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f), mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = delegate
						{
							TweenPosition.Begin(mXPRewardPoints.gameObject, 0.1f, mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
							{
								TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = delegate
								{
									TweenAlpha.Begin(mCompletedLabel.gameObject, 0.2f, AGOCILPHNOB);
									TweenAlpha.Begin(mXPRewardLabel.gameObject, 0.2f, 0f);
									TweenPosition.Begin(mXPRewardLabel.gameObject, 0.2f, mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
									TweenAlpha.Begin(mXPRewardPoints.gameObject, 0.2f, 0f);
									TweenPosition.Begin(mXPRewardPoints.gameObject, 0.2f, mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = delegate
									{
										if (!LevelManager.instance.isLevelUp)
										{
											ContinueCompletedAnimation();
										}
									};
								};
							};
						};
					};
				}
				TweenScale.Begin(mCompletedCheck.gameObject, 0.2f, BFLOBIJCMHE.MultiplyXY(3f), BFLOBIJCMHE);
				TweenAlpha.Begin(mCompletedCheck.gameObject, 0.2f, 1f);
				TweenPosition.Begin(mCompletedBackground.gameObject, 0.2f, FEFLNBHLEDI.AddY(30f), FEFLNBHLEDI);
				TweenAlpha.Begin(mCompletedBackground.gameObject, 0.2f, 1f);
			};
			TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f).onFinished = delegate
			{
				UISprite[] array = mProgressArrows;
				foreach (UISprite uISprite in array)
				{
					TweenColor.Begin(uISprite.gameObject, 0.2f, Color.black.ReplaceA(0.1f));
				}
				TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 0f).onFinished = delegate
				{
					TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
				};
			};
			TweenPosition.Begin(mScullSprite.gameObject, 0.4f, GuiScreenSingle<DailyMissionScreen>.instance.positionToAnimatePointsGain, useLocal: false);
		};
	}

	[CompilerGenerated]
	private void LILIJGGMNBJ(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mPlayButton, 0.3f, mPlayButton.transform.localPosition.ReplaceY(154f));
		UISprite[] array = mProgressArrows;
		foreach (UISprite uISprite in array)
		{
			TweenColor.Begin(uISprite.gameObject, 0.5f, Color.white);
		}
		TweenAlpha.Begin(mLockedBackground.gameObject, 0.6f, 0f);
		TweenScale.Begin(mLockedBackground.gameObject, 0.5f, PDEBIAGFDAL.MultiplyXY(2f));
		TweenScale.Begin(mNormalBackground.gameObject, 0.3f, IGHJLCNFMPG);
		TweenAlpha.Begin(mScullSprite.gameObject, 0.2f, 1f);
		TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL.MultiplyXY(1.5f), HBEDCLGBJOL.MultiplyXY(0.8f)).onFinished = delegate
		{
			TweenScale.Begin(mScullSprite.gameObject, 0.2f, HBEDCLGBJOL);
			TweenAlpha.Begin(mScullPlusSprite.gameObject, 0.2f, 1f);
			TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF.MultiplyXY(1.5f), IOCFIFJEEGF.MultiplyXY(0.8f)).onFinished = delegate
			{
				TweenScale.Begin(mScullPlusSprite.gameObject, 0.2f, IOCFIFJEEGF);
			};
		};
	}

	private void MHOPIJIJOMN(UITweener BHBCEPBDLOB)
	{
		if (GPDDCEJAJDA())
		{
			TweenAlpha.Begin(mXPRewardLabel.gameObject, 1047f, 1935f);
			TweenPosition.Begin(mXPRewardLabel.gameObject, 1074f, mXPRewardLabel.transform.localPosition.ReplaceY(841f), mXPRewardLabel.transform.localPosition.ReplaceY(1874f)).onFinished = HCOMPJGMAJB;
			TweenAlpha.Begin(mXPRewardPoints.gameObject, 1750f, 276f).onFinished = ODIMCMILLMB;
		}
		TweenScale.Begin(mCompletedCheck.gameObject, 378f, BFLOBIJCMHE.MultiplyXY(49f), BFLOBIJCMHE);
		TweenAlpha.Begin(mCompletedCheck.gameObject, 1f, 1429f);
		TweenPosition.Begin(mCompletedBackground.gameObject, 1261f, FEFLNBHLEDI.AddY(726f), FEFLNBHLEDI, useLocal: false);
		TweenAlpha.Begin(mCompletedBackground.gameObject, 1232f, 1435f);
	}

	private void ODBAILNEPFI(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mPlayButton, 686f, mPlayButton.transform.localPosition.ReplaceY(737f), useLocal: false);
	}

	private void EDMIHHBPOCE(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1157f)
		{
			PAENPHMEMGC = 91f;
		}
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num = 1299f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 1451f * (1268f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void POCDFDBJJOP(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mGlow1.gameObject, 16f, 1891f);
		TweenAlpha.Begin(mGlow2.gameObject, 1419f, 1487f).onFinished = IKBNBMMMKAN;
	}

	private void AFIAPIFAAFC()
	{
		mPlayButton.SetActive(value: true);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0f, 1f);
		TweenPosition.Begin(mNumber.gameObject, 0f, MHIAJFBLHEC);
		TweenPosition.Begin(mNormalBackground.gameObject, 0f, GPPBCDLHJMC);
		TweenScale.Begin(mNormalBackground.gameObject, 0f, IGHJLCNFMPG);
		TweenAlpha.Begin(mNormalBackground.gameObject, 0f, 1f);
		TweenScale.Begin(mSkullObject, 0f, Vector3.one);
		TweenPosition.Begin(mScullPlusSprite.gameObject, 0f, NHIMGLEKLIE);
		TweenScale.Begin(mScullPlusSprite.gameObject, 0f, IOCFIFJEEGF);
		TweenPosition.Begin(mScullSprite.gameObject, 0f, AKFOIFLDNGI);
		TweenScale.Begin(mScullSprite.gameObject, 0f, HBEDCLGBJOL);
		TweenAlpha.Begin(mScullPlusSprite.gameObject, 0f, 1f);
		TweenAlpha.Begin(mScullSprite.gameObject, 0f, 1f);
		TweenAlpha.Begin(mGlow1.gameObject, 0f, 1f);
		TweenAlpha.Begin(mGlow2.gameObject, 0f, 1f);
		TweenPosition.Begin(mCompletedBackground.gameObject, 0f, FEFLNBHLEDI);
		TweenAlpha.Begin(mCompletedBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mCompletedCheck.gameObject, 0f, 1f);
		TweenAlpha.Begin(mCompletedLabel.gameObject, 0f, AGOCILPHNOB);
		if (LOOAGDCIEIB)
		{
			mRewardsObject.SetActive(value: false);
			TweenAlpha.Begin(mXPRewardLabel.gameObject, 0f, 0f);
			TweenAlpha.Begin(mXPRewardPoints.gameObject, 0f, 0f);
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0f, 0f);
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0f, 0f);
		}
		TweenScale.Begin(mLockedLock.gameObject, 0f, EJELJJMLBGE);
		TweenAlpha.Begin(mLockedLock.gameObject, 0f, 1f);
		TweenScale.Begin(mLockedBackground.gameObject, 0f, PDEBIAGFDAL);
		TweenAlpha.Begin(mLockedBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mLockedSkull.gameObject, 0f, 0.25f);
		TweenAlpha.Begin(mLockedLabel.gameObject, 0f, 1f);
	}

	private void ADCCFCDFNGI(bool ECEOFMAEOGE)
	{
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(0.1f));
			}
		}
	}

	private void HOOFCEPHHEO(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mGlow1.gameObject, 355f, 1258f);
		TweenAlpha.Begin(mGlow2.gameObject, 1099f, 1811f);
		TweenPosition.Begin(mNormalBackground.gameObject, 1919f, GPPBCDLHJMC).onFinished = delegate
		{
			if (LOOAGDCIEIB)
			{
				TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
				TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 0.2f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
			}
			TweenPosition.Begin(mNormalBackground.gameObject, 0.2f, GPPBCDLHJMC.AddY(-30f));
			TweenAlpha.Begin(mNormalBackground.gameObject, 0.2f, 0f);
			TweenColor.Begin(mNumber.gameObject, 0.3f, Color.black, Color.white);
			TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC.AddY(10f)).onFinished = delegate
			{
				TweenPosition.Begin(mNumber.gameObject, 0.15f, MHIAJFBLHEC);
			};
		};
		TweenPosition.Begin(mCompletedBackground.gameObject, 1517f, FEFLNBHLEDI, useLocal: false).onFinished = MHOPIJIJOMN;
		TweenAlpha.Begin(mScullSprite.gameObject, 320f, 603f).onFinished = MNHHFAJFEAH;
		TweenPosition.Begin(mScullSprite.gameObject, 1161f, GuiScreenSingle<DailyMissionScreen>.instance.NGCBJNLCGAF());
	}

	public void MHBOBFBDNOC()
	{
		KIKCJMILKLG();
		mButtonCollider.enabled = false;
		TweenAlpha.Begin(mGlow1.gameObject, 782f, 1131f).onFinished = POCDFDBJJOP;
	}

	private void LOMAFKIMCDC()
	{
		if (LOOAGDCIEIB)
		{
			foreach (CDACJEGCGLB reward in DPGPOMCNMNF.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.XP)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: true);
			float num = 20f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 20f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(-10f - num / 2f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(-10f - num2 / 2f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = true;
		}
		mAnimationObject.SetActive(value: false);
		mProgressPart.SetActive(value: true);
		mDoneProgress.gameObject.SetActive(value: true);
		LALJLMACNJO = false;
		mNormalPart.SetActive(value: true);
		mCompletedPart.SetActive(value: true);
		TweenAlpha.Begin(mDoneProgress.gameObject, 0f, 0f);
		TweenAlpha.Begin(mCompletedBackground.gameObject, 0f, 0f);
		TweenAlpha.Begin(mCompletedCheck.gameObject, 0f, 0f);
		TweenAlpha.Begin(mCompletedLabel.gameObject, 0f, 0f);
		ADCCFCDFNGI(ECEOFMAEOGE: false);
		mNumber.color = Color.black;
	}

	[CompilerGenerated]
	private void BOICKPKKAKJ(UITweener PNIJONDHIHC)
	{
		if (!LevelManager.instance.isLevelUp)
		{
			ContinueCompletedAnimation();
		}
	}

	private void BHIABNNGKFO()
	{
		if (LALJLMACNJO && mSpeed > 598f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			JJBDAMAFBNC(num / mSpeed);
		}
	}

	private void GIHPPCJNKLK(UITweener AAHDNEKFJOA)
	{
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 1577f, 652f).onFinished = MNEOBJLNDCN;
	}

	private void DJKDBFFCJLJ(UITweener BDEOMPEJELN)
	{
		TweenPosition.Begin(mWarbucksRewardAmount.gameObject, 1623f, mWarbucksRewardAmount.transform.localPosition.ReplaceY(12f), useLocal: false);
	}

	private void HBIIHLAAJFK(UITweener AEEBLJKPGMO)
	{
		UISprite[] array = mProgressArrows;
		foreach (UISprite uISprite in array)
		{
			TweenColor.Begin(uISprite.gameObject, 99f, Color.black.ReplaceA(1505f));
		}
		TweenAlpha.Begin(mScullSprite.gameObject, 525f, 1479f).onFinished = delegate
		{
			TweenAlpha.Begin(mDoneProgress.gameObject, 0.2f, 1f);
		};
	}

	private void HLCMDJHGBPD()
	{
		Vector3 vector = new Vector3(1271f, 1029f, 925f);
		TweenScale tweenScale = TweenScale.Begin(mAnimationObject, 52f, vector, vector.MultiplyXY(167f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mAnimationSprite.gameObject, 1760f, 791f, 1086f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	private void OOGKOGNBOOJ(UITweener PNIJONDHIHC)
	{
		if (!LevelManager.instance.isLevelUp)
		{
			ABJOHDHGBNH();
		}
	}

	private void JNFPPBDAHFK(GameObject KHAHPAKDIKE)
	{
		if (DPGPOMCNMNF != null)
		{
			GuiElementSingle<DailyMissionDialog>.instance.ShowDialog(DPGPOMCNMNF);
			DailyMissionsManager.instance.currentMission = DPGPOMCNMNF;
		}
	}

	private void MMNMPKBOAGB(UITweener NPAJIAIILLL)
	{
		TweenScale.Begin(mScullPlusSprite.gameObject, 312f, IOCFIFJEEGF);
	}
}
