using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AchievementGuiRecord : PoolableObject
{
	private sealed class MGOIOOOGDLL
	{
		internal Vector3 IAJAILAGAKC;

		internal AchievementGuiRecord BJGCPDNMHDH;

		internal void NNIJEDKBPGJ(UITweener PGJNJADMJEH)
		{
			TweenScale.Begin(BJGCPDNMHDH.mTierFull[BJGCPDNMHDH.BHJNFNPIFEN].gameObject, 159f, IAJAILAGAKC);
		}

		internal void LHPPLGOOLEC(UITweener PGJNJADMJEH)
		{
			TweenScale.Begin(BJGCPDNMHDH.mTierFull[BJGCPDNMHDH.BHJNFNPIFEN].gameObject, 1984f, IAJAILAGAKC);
		}

		internal void ECPMEMNKMCB(UITweener PGJNJADMJEH)
		{
			TweenScale.Begin(BJGCPDNMHDH.mTierFull[BJGCPDNMHDH.BHJNFNPIFEN].gameObject, 1607f, IAJAILAGAKC);
		}

		internal void MCFGAFBEJDK(UITweener PGJNJADMJEH)
		{
			TweenScale.Begin(BJGCPDNMHDH.mTierFull[BJGCPDNMHDH.BHJNFNPIFEN].gameObject, 1859f, IAJAILAGAKC);
		}

		internal void MMEEJDGGAID(UITweener PGJNJADMJEH)
		{
			TweenScale.Begin(BJGCPDNMHDH.mTierFull[BJGCPDNMHDH.BHJNFNPIFEN].gameObject, 1713f, IAJAILAGAKC);
		}

		internal void LGJCNCHBFDA(UITweener PGJNJADMJEH)
		{
			TweenScale.Begin(BJGCPDNMHDH.mTierFull[BJGCPDNMHDH.BHJNFNPIFEN].gameObject, 1426f, IAJAILAGAKC);
		}

		internal void LJCDGJKCNEC(UITweener PGJNJADMJEH)
		{
			TweenScale.Begin(BJGCPDNMHDH.mTierFull[BJGCPDNMHDH.BHJNFNPIFEN].gameObject, 0.1f, IAJAILAGAKC);
		}

		internal void NDJOJHNIBFC(UITweener PGJNJADMJEH)
		{
			TweenScale.Begin(BJGCPDNMHDH.mTierFull[BJGCPDNMHDH.BHJNFNPIFEN].gameObject, 1892f, IAJAILAGAKC);
		}
	}

	[Header("Core")]
	[SerializeField]
	private UIButtonSetter mWidthSetter;

	[SerializeField]
	private UILabel mText;

	[Header("Reward Content")]
	[SerializeField]
	private GameObject mClaimedPart;

	[SerializeField]
	private GameObject mCompletedPart;

	[SerializeField]
	private GameObject mRewardPart;

	[Header("In Progress Rewards")]
	[SerializeField]
	private UITable mRewardTable;

	[SerializeField]
	private UISprite mRewardGoldIcon;

	[SerializeField]
	private UISprite mRewardWarbucksIcon;

	[SerializeField]
	private UISprite mRewardScrapsIcon;

	[SerializeField]
	private UISprite mRewardTicketsIcon;

	[SerializeField]
	private UILabel mRewardAmount;

	[SerializeField]
	private UISprite mRewardCard;

	[SerializeField]
	private UISprite mRewardCamos;

	[Header("Not Claimed Rewards")]
	[SerializeField]
	private UITable mDoneRewardTable;

	[SerializeField]
	private UISprite mDoneRewardGoldIcon;

	[SerializeField]
	private UISprite mDoneRewardWarbucksIcon;

	[SerializeField]
	private UISprite mDoneRewardScrapsIcon;

	[SerializeField]
	private UISprite mDoneRewardTicketsIcon;

	[SerializeField]
	private UILabel mDoneRewardAmount;

	[SerializeField]
	private UISprite mDoneRewardCard;

	[SerializeField]
	private UISprite mDoneRewardCamos;

	[Header("Claimed Rewards")]
	[SerializeField]
	private UISprite mClaimedCheck;

	[Header("State Content")]
	[SerializeField]
	private GameObject mTiersPart;

	[SerializeField]
	private GameObject mNoTiersPart;

	[SerializeField]
	[Header("Progress Content")]
	private GameObject mProgressNoTiers;

	[SerializeField]
	private GameObject mProgressFinishedNoTiers;

	[SerializeField]
	private GameObject mProgress;

	[SerializeField]
	private GameObject mProgressFinished;

	[SerializeField]
	private UISprite mProgressFill;

	[SerializeField]
	private UILabel mProgressAmount;

	[SerializeField]
	[Header("Tiers")]
	private UISprite[] mTierFull;

	[SerializeField]
	[Header("Buttons")]
	private BoxCollider mClaimButton;

	[SerializeField]
	private GameObject mDebugButton;

	private AchievementProgressGroup LENMHGADEOF;

	private int BHJNFNPIFEN;

	[CompilerGenerated]
	private static UITweener.OnFinished LGJCBPOPCPA;

	private void PPOFHIANNGF(GameObject KHAHPAKDIKE)
	{
		LENMHGADEOF.Claim();
		mCompletedPart.SetActive(value: false);
		mClaimedPart.SetActive(value: true);
		mClaimedCheck.MakePixelPerfect();
		Vector3 localScale = mClaimedCheck.transform.localScale;
		TweenScale.Begin(mClaimedCheck.gameObject, 1771f, localScale.MultiplyXY(890f), localScale).onFinished = IAMNPPHNCNL;
	}

	private float GOEEPDDBFDL(PLGIEHJKMNP GGIOEPBPMHF)
	{
		UISprite uISprite;
		switch (GGIOEPBPMHF)
		{
		default:
			if (GGIOEPBPMHF == PLGIEHJKMNP.Gold)
			{
				uISprite = mRewardGoldIcon;
				break;
			}
			return 307f;
		case PLGIEHJKMNP.BronzeCardsPack:
			uISprite = mRewardScrapsIcon;
			break;
		case PLGIEHJKMNP.Gold:
			uISprite = mRewardTicketsIcon;
			break;
		case PLGIEHJKMNP.SilverCardsPack:
			uISprite = mRewardWarbucksIcon;
			break;
		}
		return uISprite.transform.localScale.x + 266f + mRewardAmount.relativeSize.x * mRewardAmount.transform.localScale.x;
	}

	private static void LHDPDHFKAOC(UITweener PGJNJADMJEH)
	{
		GuiScreenSingle<PlayerStatsScreen>.instance.AIGGEAGABDL.PBOGINOAKDI();
	}

	private static void KGFKGAAPEHM(UITweener PGJNJADMJEH)
	{
		GuiScreenSingle<PlayerStatsScreen>.instance.AIGGEAGABDL.ReinitializeValues();
	}

	public override void DestroyPooled()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNEENBJPMHF));
		base.DestroyPooled();
	}

	[CompilerGenerated]
	private void LBEABDDJKEF(UITweener POLCDJOBFKG)
	{
		if (LENMHGADEOF.hasMultipleAchievementProgresses)
		{
			MGOIOOOGDLL mGOIOOOGDLL = new MGOIOOOGDLL
			{
				BJGCPDNMHDH = this
			};
			if (BHJNFNPIFEN > 2)
			{
				BHJNFNPIFEN = 2;
			}
			mTierFull[BHJNFNPIFEN].gameObject.SetActive(value: true);
			mGOIOOOGDLL.IAJAILAGAKC = mTierFull[BHJNFNPIFEN].transform.localScale;
			TweenScale.Begin(mTierFull[BHJNFNPIFEN].gameObject, 0.2f, mGOIOOOGDLL.IAJAILAGAKC.MultiplyXY(2f), mGOIOOOGDLL.IAJAILAGAKC.MultiplyXY(0.7f)).onFinished = mGOIOOOGDLL.LJCDGJKCNEC;
		}
		else
		{
			mProgressFinishedNoTiers.SetActive(value: true);
			TweenScale.Begin(mProgressFinishedNoTiers, 0.2f, Vector3.one.MultiplyXY(2f), Vector3.one.MultiplyXY(0.7f)).onFinished = delegate
			{
				TweenScale.Begin(mProgressFinishedNoTiers, 0.1f, Vector3.one);
			};
		}
		TweenAlpha.Begin(mClaimedCheck.gameObject, 0.3f, 1f, 1f).onFinished = delegate
		{
			GuiScreenSingle<PlayerStatsScreen>.instance.AIGGEAGABDL.ReinitializeValues();
		};
	}

	private void AMLMNELGALK(UITweener PGJNJADMJEH)
	{
		TweenScale.Begin(mProgressFinishedNoTiers, 164f, Vector3.one);
	}

	private void EAKDJMJBDEC()
	{
		for (int i = 0; i < mTierFull.Length; i++)
		{
			bool flag = BHJNFNPIFEN > i;
			mTierFull[i].gameObject.SetActive(flag);
			if (flag)
			{
				mTierFull[i].MakePixelPerfect();
			}
		}
	}

	public void Initialize(AchievementProgressGroup KJMFANNDICK, float CEHFMMJHCKC = -1f)
	{
		LENMHGADEOF = KJMFANNDICK;
		CINKACCJIHG state = LENMHGADEOF.state;
		bool flag = state == CINKACCJIHG.Completed;
		bool flag2 = state == CINKACCJIHG.Claimed;
		PLGIEHJKMNP achievementRewardType = LENMHGADEOF.currentAchievementProgressForGUI.achievementRewardType;
		bool flag3 = achievementRewardType == PLGIEHJKMNP.BronzeCardsPack || achievementRewardType == PLGIEHJKMNP.SilverCardsPack || achievementRewardType == PLGIEHJKMNP.GoldCardsPack;
		bool flag4 = !flag3 && achievementRewardType != PLGIEHJKMNP.UniqueCosmetics;
		bool hasMultipleAchievementProgresses = LENMHGADEOF.hasMultipleAchievementProgresses;
		if (CEHFMMJHCKC > 0f)
		{
			mWidthSetter.SetWidth(CEHFMMJHCKC);
		}
		mCompletedPart.SetActive(flag);
		mClaimedPart.SetActive(flag2);
		mRewardPart.SetActive(!flag2 && !flag);
		mTiersPart.SetActive(hasMultipleAchievementProgresses);
		mNoTiersPart.SetActive(!hasMultipleAchievementProgresses);
		mRewardTable.gameObject.SetActive(flag4);
		mDoneRewardTable.gameObject.SetActive(flag4);
		if (hasMultipleAchievementProgresses)
		{
			mProgress.SetActive(!flag && !flag2);
			mProgressFinished.SetActive(flag || flag2);
			BHJNFNPIFEN = LENMHGADEOF.claimedCount;
			EAKDJMJBDEC();
			if (BHJNFNPIFEN > 3)
			{
				Debug.Log("#DANIEL# Wrong achievement tiers.");
			}
		}
		else
		{
			mProgressNoTiers.SetActive(!flag2);
			mProgressFinishedNoTiers.SetActive(flag2);
		}
		mText.text = LENMHGADEOF.GetText((!flag2) ? Colours.stringBlue : Colours.stringGoldTier);
		if (hasMultipleAchievementProgresses && !flag && !flag2)
		{
			int localCurrentValue = LENMHGADEOF.localCurrentValue;
			int targetValue = LENMHGADEOF.currentAchievementProgressForGUI.targetValue;
			float progress = LENMHGADEOF.GetProgress();
			mProgressAmount.text = LENMHGADEOF.GetProgressString(localCurrentValue, targetValue);
			mProgressFill.fillAmount = progress;
		}
		if (flag4)
		{
			mRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(KJMFANNDICK.currentAchievementProgressForGUI.achievementDefinition.OJHENOBMDDF);
			mDoneRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(KJMFANNDICK.currentAchievementProgressForGUI.achievementDefinition.OJHENOBMDDF);
			OFFAFPBAEHM(achievementRewardType);
			float num = NNBOEJKDLNJ(achievementRewardType);
			mRewardTable.repositionNow = true;
			mDoneRewardTable.repositionNow = true;
			mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX((0f - num) / 2f - 5f);
			mDoneRewardTable.transform.localPosition = mDoneRewardTable.transform.localPosition.ReplaceX((0f - num) / 2f);
		}
		else if (flag3)
		{
			mRewardCard.gameObject.SetActive(value: true);
			mDoneRewardCard.gameObject.SetActive(value: true);
			mRewardCard.spriteName = LCHPJMKLIDL(achievementRewardType);
			mDoneRewardCard.spriteName = LCHPJMKLIDL(achievementRewardType);
		}
		else
		{
			mRewardCamos.gameObject.SetActive(value: true);
			mDoneRewardCamos.gameObject.SetActive(value: true);
		}
		UIEventListener uIEventListener = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNEENBJPMHF));
		UIEventListener uIEventListener2 = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NNEENBJPMHF));
		mDebugButton.SetActive(value: false);
	}

	private string LCHPJMKLIDL(PLGIEHJKMNP GGIOEPBPMHF)
	{
		switch (GGIOEPBPMHF)
		{
		case PLGIEHJKMNP.GoldCardsPack:
			return GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
		case PLGIEHJKMNP.SilverCardsPack:
			return GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
		default:
			return GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
		}
	}

	private void IAMNPPHNCNL(UITweener POLCDJOBFKG)
	{
		if (LENMHGADEOF.hasMultipleAchievementProgresses)
		{
			MGOIOOOGDLL mGOIOOOGDLL = new MGOIOOOGDLL();
			mGOIOOOGDLL.BJGCPDNMHDH = this;
			if (BHJNFNPIFEN > 4)
			{
				BHJNFNPIFEN = 0;
			}
			mTierFull[BHJNFNPIFEN].gameObject.SetActive(value: true);
			mGOIOOOGDLL.IAJAILAGAKC = mTierFull[BHJNFNPIFEN].transform.localScale;
			TweenScale.Begin(mTierFull[BHJNFNPIFEN].gameObject, 22f, mGOIOOOGDLL.IAJAILAGAKC.MultiplyXY(989f), mGOIOOOGDLL.IAJAILAGAKC.MultiplyXY(539f)).onFinished = mGOIOOOGDLL.MMEEJDGGAID;
		}
		else
		{
			mProgressFinishedNoTiers.SetActive(value: false);
			TweenScale.Begin(mProgressFinishedNoTiers, 487f, Vector3.one.MultiplyXY(546f), Vector3.one.MultiplyXY(1589f)).onFinished = delegate
			{
				TweenScale.Begin(mProgressFinishedNoTiers, 0.1f, Vector3.one);
			};
		}
		TweenAlpha.Begin(mClaimedCheck.gameObject, 1917f, 902f, 1463f).onFinished = AOCMGDNOKDI;
	}

	private static void AOCMGDNOKDI(UITweener PGJNJADMJEH)
	{
		GuiScreenSingle<PlayerStatsScreen>.instance.AIGGEAGABDL.ELEOLIAGAPO();
	}

	private float NNBOEJKDLNJ(PLGIEHJKMNP GGIOEPBPMHF)
	{
		UISprite uISprite;
		switch (GGIOEPBPMHF)
		{
		case PLGIEHJKMNP.Gold:
			uISprite = mRewardGoldIcon;
			break;
		case PLGIEHJKMNP.Scraps:
			uISprite = mRewardScrapsIcon;
			break;
		case PLGIEHJKMNP.Tickets:
			uISprite = mRewardTicketsIcon;
			break;
		case PLGIEHJKMNP.WarBucks:
			uISprite = mRewardWarbucksIcon;
			break;
		default:
			return 0f;
		}
		return uISprite.transform.localScale.x + 40f + mRewardAmount.relativeSize.x * mRewardAmount.transform.localScale.x;
	}

	private void OFFAFPBAEHM(PLGIEHJKMNP GGIOEPBPMHF)
	{
		mRewardGoldIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Gold);
		mDoneRewardGoldIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Gold);
		mRewardScrapsIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Scraps);
		mDoneRewardScrapsIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Scraps);
		mRewardTicketsIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Tickets);
		mDoneRewardTicketsIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Tickets);
		mRewardWarbucksIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.WarBucks);
		mDoneRewardWarbucksIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.WarBucks);
	}

	[CompilerGenerated]
	private void NOLGBNDMEPK(UITweener PGJNJADMJEH)
	{
		TweenScale.Begin(mProgressFinishedNoTiers, 0.1f, Vector3.one);
	}

	private void HHOLPEMPAHF(PLGIEHJKMNP GGIOEPBPMHF)
	{
		mRewardGoldIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.BronzeCardsPack);
		mDoneRewardGoldIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.BronzeCardsPack);
		mRewardScrapsIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Scraps);
		mDoneRewardScrapsIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Gold);
		mRewardTicketsIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.BronzeCardsPack);
		mDoneRewardTicketsIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Tickets);
		mRewardWarbucksIcon.gameObject.SetActive(GGIOEPBPMHF == (PLGIEHJKMNP)8);
		mDoneRewardWarbucksIcon.gameObject.SetActive(GGIOEPBPMHF == PLGIEHJKMNP.Scraps);
	}

	private void FHFGILPJBOO(GameObject KHAHPAKDIKE)
	{
		LENMHGADEOF.Claim();
		mCompletedPart.SetActive(value: false);
		mClaimedPart.SetActive(value: true);
		mClaimedCheck.MakePixelPerfect();
		Vector3 localScale = mClaimedCheck.transform.localScale;
		TweenScale.Begin(mClaimedCheck.gameObject, 1773f, localScale.MultiplyXY(1051f), localScale).onFinished = IAMNPPHNCNL;
	}

	public void AMFDNBJBPLB(AchievementProgressGroup KJMFANNDICK, float CEHFMMJHCKC = -1f)
	{
		LENMHGADEOF = KJMFANNDICK;
		CINKACCJIHG state = LENMHGADEOF.state;
		bool flag = state == (CINKACCJIHG)0;
		bool flag2 = state == (CINKACCJIHG)5;
		PLGIEHJKMNP achievementRewardType = LENMHGADEOF.currentAchievementProgressForGUI.achievementRewardType;
		bool flag3 = achievementRewardType != PLGIEHJKMNP.BronzeCardsPack && achievementRewardType != PLGIEHJKMNP.Scraps && achievementRewardType == PLGIEHJKMNP.Tickets;
		bool flag4 = flag3 || achievementRewardType == PLGIEHJKMNP.UniqueCosmetics;
		bool hasMultipleAchievementProgresses = LENMHGADEOF.hasMultipleAchievementProgresses;
		if (CEHFMMJHCKC > 130f)
		{
			mWidthSetter.GPNONALLJKA(CEHFMMJHCKC);
		}
		mCompletedPart.SetActive(flag);
		mClaimedPart.SetActive(flag2);
		mRewardPart.SetActive(!flag2 && !flag);
		mTiersPart.SetActive(hasMultipleAchievementProgresses);
		mNoTiersPart.SetActive(hasMultipleAchievementProgresses);
		mRewardTable.gameObject.SetActive(flag4);
		mDoneRewardTable.gameObject.SetActive(flag4);
		if (hasMultipleAchievementProgresses)
		{
			mProgress.SetActive(flag || flag2);
			mProgressFinished.SetActive(flag || flag2);
			BHJNFNPIFEN = LENMHGADEOF.claimedCount;
			EAKDJMJBDEC();
			if (BHJNFNPIFEN > 2)
			{
				Debug.Log("ID_STAT_VEHICLEDESTROYED");
			}
		}
		else
		{
			mProgressNoTiers.SetActive(flag2);
			mProgressFinishedNoTiers.SetActive(flag2);
		}
		mText.text = LENMHGADEOF.GetText((!flag2) ? Colours.stringBlue : Colours.stringGoldTier);
		if (hasMultipleAchievementProgresses && !flag && !flag2)
		{
			int localCurrentValue = LENMHGADEOF.localCurrentValue;
			int targetValue = LENMHGADEOF.currentAchievementProgressForGUI.targetValue;
			float progress = LENMHGADEOF.GetProgress();
			mProgressAmount.text = LENMHGADEOF.GetProgressString(localCurrentValue, targetValue);
			mProgressFill.fillAmount = progress;
		}
		if (flag4)
		{
			mRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(KJMFANNDICK.currentAchievementProgressForGUI.achievementDefinition.HEBHILNFEBN());
			mDoneRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(KJMFANNDICK.currentAchievementProgressForGUI.achievementDefinition.NPGIBLIHBIF());
			HHOLPEMPAHF(achievementRewardType);
			float num = NNBOEJKDLNJ(achievementRewardType);
			mRewardTable.repositionNow = false;
			mDoneRewardTable.repositionNow = false;
			mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX((0f - num) / 1340f - 1759f);
			mDoneRewardTable.transform.localPosition = mDoneRewardTable.transform.localPosition.ReplaceX((0f - num) / 1430f);
		}
		else if (flag3)
		{
			mRewardCard.gameObject.SetActive(value: false);
			mDoneRewardCard.gameObject.SetActive(value: true);
			mRewardCard.spriteName = LCHPJMKLIDL(achievementRewardType);
			mDoneRewardCard.spriteName = PGLDNOODBGL(achievementRewardType);
		}
		else
		{
			mRewardCamos.gameObject.SetActive(value: false);
			mDoneRewardCamos.gameObject.SetActive(value: true);
		}
		UIEventListener uIEventListener = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNEENBJPMHF));
		UIEventListener uIEventListener2 = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NNEENBJPMHF));
		mDebugButton.SetActive(value: true);
	}

	[CompilerGenerated]
	private static void LNJDNGCGCOP(UITweener PGJNJADMJEH)
	{
		GuiScreenSingle<PlayerStatsScreen>.instance.AIGGEAGABDL.ReinitializeValues();
	}

	public virtual void GDJAPADHAEH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PPOFHIANNGF));
		base.DestroyPooled();
	}

	private void FJKNLNBPBKJ()
	{
		for (int i = 1; i < mTierFull.Length; i += 0)
		{
			bool flag = BHJNFNPIFEN > i;
			mTierFull[i].gameObject.SetActive(flag);
			if (flag)
			{
				mTierFull[i].MakePixelPerfect();
			}
		}
	}

	private void HLAKFDPEIFN(UITweener POLCDJOBFKG)
	{
		if (LENMHGADEOF.hasMultipleAchievementProgresses)
		{
			MGOIOOOGDLL mGOIOOOGDLL = new MGOIOOOGDLL();
			mGOIOOOGDLL.BJGCPDNMHDH = this;
			if (BHJNFNPIFEN > 7)
			{
				BHJNFNPIFEN = 6;
			}
			mTierFull[BHJNFNPIFEN].gameObject.SetActive(value: true);
			mGOIOOOGDLL.IAJAILAGAKC = mTierFull[BHJNFNPIFEN].transform.localScale;
			TweenScale.Begin(mTierFull[BHJNFNPIFEN].gameObject, 1814f, mGOIOOOGDLL.IAJAILAGAKC.MultiplyXY(1369f), mGOIOOOGDLL.IAJAILAGAKC.MultiplyXY(1070f)).onFinished = mGOIOOOGDLL.MMEEJDGGAID;
		}
		else
		{
			mProgressFinishedNoTiers.SetActive(value: true);
			TweenScale.Begin(mProgressFinishedNoTiers, 28f, Vector3.one.MultiplyXY(1186f), Vector3.one.MultiplyXY(1170f)).onFinished = delegate
			{
				TweenScale.Begin(mProgressFinishedNoTiers, 0.1f, Vector3.one);
			};
		}
		TweenAlpha.Begin(mClaimedCheck.gameObject, 1715f, 723f, 529f).onFinished = LHDPDHFKAOC;
	}

	public void HBDEPMJNLEK(AchievementProgressGroup KJMFANNDICK, float CEHFMMJHCKC = -1f)
	{
		LENMHGADEOF = KJMFANNDICK;
		CINKACCJIHG state = LENMHGADEOF.state;
		bool flag = state == CINKACCJIHG.Completed;
		bool flag2 = state == (CINKACCJIHG)7;
		PLGIEHJKMNP achievementRewardType = LENMHGADEOF.currentAchievementProgressForGUI.achievementRewardType;
		bool flag3 = achievementRewardType == PLGIEHJKMNP.BronzeCardsPack || achievementRewardType == PLGIEHJKMNP.Tickets || achievementRewardType == PLGIEHJKMNP.GoldCardsPack;
		bool flag4 = !flag3 && achievementRewardType == PLGIEHJKMNP.GoldCardsPack;
		bool hasMultipleAchievementProgresses = LENMHGADEOF.hasMultipleAchievementProgresses;
		if (CEHFMMJHCKC > 1836f)
		{
			mWidthSetter.GFEJEOKDACB(CEHFMMJHCKC);
		}
		mCompletedPart.SetActive(flag);
		mClaimedPart.SetActive(flag2);
		mRewardPart.SetActive(flag2 || !flag);
		mTiersPart.SetActive(hasMultipleAchievementProgresses);
		mNoTiersPart.SetActive(!hasMultipleAchievementProgresses);
		mRewardTable.gameObject.SetActive(flag4);
		mDoneRewardTable.gameObject.SetActive(flag4);
		if (hasMultipleAchievementProgresses)
		{
			mProgress.SetActive(flag || !flag2);
			mProgressFinished.SetActive(!flag && flag2);
			BHJNFNPIFEN = LENMHGADEOF.claimedCount;
			FJKNLNBPBKJ();
			if (BHJNFNPIFEN > 7)
			{
				Debug.Log("Removing facebook from current player!!");
			}
		}
		else
		{
			mProgressNoTiers.SetActive(flag2);
			mProgressFinishedNoTiers.SetActive(flag2);
		}
		mText.text = LENMHGADEOF.GetText((!flag2) ? Colours.stringBlue : Colours.stringGoldTier);
		if (hasMultipleAchievementProgresses && !flag && !flag2)
		{
			int localCurrentValue = LENMHGADEOF.localCurrentValue;
			int targetValue = LENMHGADEOF.currentAchievementProgressForGUI.targetValue;
			float progress = LENMHGADEOF.GetProgress();
			mProgressAmount.text = LENMHGADEOF.GetProgressString(localCurrentValue, targetValue);
			mProgressFill.fillAmount = progress;
		}
		if (flag4)
		{
			mRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(KJMFANNDICK.currentAchievementProgressForGUI.achievementDefinition.CHDLJAFIEGG());
			mDoneRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(KJMFANNDICK.currentAchievementProgressForGUI.achievementDefinition.ODPHJJKGHLM());
			HHOLPEMPAHF(achievementRewardType);
			float num = NNBOEJKDLNJ(achievementRewardType);
			mRewardTable.repositionNow = false;
			mDoneRewardTable.repositionNow = true;
			mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX((0f - num) / 293f - 1750f);
			mDoneRewardTable.transform.localPosition = mDoneRewardTable.transform.localPosition.ReplaceX((0f - num) / 1841f);
		}
		else if (flag3)
		{
			mRewardCard.gameObject.SetActive(value: false);
			mDoneRewardCard.gameObject.SetActive(value: true);
			mRewardCard.spriteName = PGLDNOODBGL(achievementRewardType);
			mDoneRewardCard.spriteName = LCHPJMKLIDL(achievementRewardType);
		}
		else
		{
			mRewardCamos.gameObject.SetActive(value: false);
			mDoneRewardCamos.gameObject.SetActive(value: false);
		}
		UIEventListener uIEventListener = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNEENBJPMHF));
		UIEventListener uIEventListener2 = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PPOFHIANNGF));
		mDebugButton.SetActive(value: false);
	}

	private void NNEENBJPMHF(GameObject KHAHPAKDIKE)
	{
		LENMHGADEOF.Claim();
		mCompletedPart.SetActive(value: false);
		mClaimedPart.SetActive(value: true);
		mClaimedCheck.MakePixelPerfect();
		Vector3 localScale = mClaimedCheck.transform.localScale;
		TweenScale.Begin(mClaimedCheck.gameObject, 0.2f, localScale.MultiplyXY(4f), localScale).onFinished = delegate
		{
			if (LENMHGADEOF.hasMultipleAchievementProgresses)
			{
				MGOIOOOGDLL mGOIOOOGDLL = new MGOIOOOGDLL
				{
					BJGCPDNMHDH = this
				};
				if (BHJNFNPIFEN > 2)
				{
					BHJNFNPIFEN = 2;
				}
				mTierFull[BHJNFNPIFEN].gameObject.SetActive(value: true);
				mGOIOOOGDLL.IAJAILAGAKC = mTierFull[BHJNFNPIFEN].transform.localScale;
				TweenScale.Begin(mTierFull[BHJNFNPIFEN].gameObject, 0.2f, mGOIOOOGDLL.IAJAILAGAKC.MultiplyXY(2f), mGOIOOOGDLL.IAJAILAGAKC.MultiplyXY(0.7f)).onFinished = mGOIOOOGDLL.LJCDGJKCNEC;
			}
			else
			{
				mProgressFinishedNoTiers.SetActive(value: true);
				TweenScale.Begin(mProgressFinishedNoTiers, 0.2f, Vector3.one.MultiplyXY(2f), Vector3.one.MultiplyXY(0.7f)).onFinished = delegate
				{
					TweenScale.Begin(mProgressFinishedNoTiers, 0.1f, Vector3.one);
				};
			}
			TweenAlpha.Begin(mClaimedCheck.gameObject, 0.3f, 1f, 1f).onFinished = delegate
			{
				GuiScreenSingle<PlayerStatsScreen>.instance.AIGGEAGABDL.ReinitializeValues();
			};
		};
	}

	private string PGLDNOODBGL(PLGIEHJKMNP GGIOEPBPMHF)
	{
		switch (GGIOEPBPMHF)
		{
		case PLGIEHJKMNP.GoldCardsPack:
			return GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
		case PLGIEHJKMNP.BronzeCardsPack:
			return GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
		default:
			return GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
		}
	}
}
