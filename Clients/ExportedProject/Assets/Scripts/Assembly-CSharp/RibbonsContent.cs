using System;
using System.Collections.Generic;
using UnityEngine;

public class RibbonsContent : Core_BaseScript
{
	[Header("List of Content")]
	public UITable table;

	public UIDraggablePanel panelRibbons;

	public GameObject topSpacer;

	[Header("Ribbon Header")]
	public UILabel ribbonHeader;

	[Header("No Ribbons")]
	public GameObject noRibbonsGained;

	public UISprite noRibbonsBackground;

	public UILabel noRibbonsText;

	[Header("List of Ribbons")]
	public RibbonGuiRecord ribbonGuiRecordPrefab;

	public UIPooledGrid gainedRibbons;

	[Header("Skillshot Header")]
	public UILabel skillshotHeader;

	[Header("Player info")]
	public PlayerIcon myIcon;

	public GameObject playerIconButton;

	public GameObject playerObject;

	public GameObject playerButton;

	public GameObject vsObject;

	public PlayerIcon oponentIcon;

	public GameObject opponentIconButton;

	public BoxCollider opponentCollider;

	public GameObject opponentObject;

	public GameObject opponentButton;

	[Header("List of Skillshots")]
	public SkillshotGuiRecord skillshotGuiRecordPrefab;

	public UIGrid gridSkillshot;

	private List<TweenAnimator> mAnimator = new List<TweenAnimator>();

	private TweenAnimator mAnimatorRibbonsEmpty;

	private TweenAnimator mAnimatorRibbons;

	private TweenAnimator mAnimatorSkillshotsHeaderSingle;

	private TweenAnimator mAnimatorSkillshotsHeaderMulti;

	private TweenAnimator mAnimatorSkillshots;

	private ObjectPool mPool;

	private List<Tuple<RibbonManager.RibbonItemDefinition, int>> mDisplayedRibbons = new List<Tuple<RibbonManager.RibbonItemDefinition, int>>();

	private List<SkillshotGuiRecord> mSkillshotRecords;

	private string mOpponentPlayerId;

	public List<TweenAnimator> Animator => mAnimator;

	private bool mIsSinglePlayer => Singleton<GameController>.instance.isCampaign || Singleton<GameController>.instance.isCoop;

	public void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		mAnimator = new List<TweenAnimator>();
		mAnimatorRibbonsEmpty = base.gameObject.AddComponent<TweenAnimator>();
		mAnimatorRibbonsEmpty.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimatorRibbonsEmpty.AddTween(1, TweenAnimator.TweenType.Alpha, ribbonHeader.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimatorRibbonsEmpty.AddTween(2, TweenAnimator.TweenType.Alpha, noRibbonsBackground.gameObject, 0.5f, 0.25f, 0f, 1, 0f);
		mAnimatorRibbonsEmpty.AddTween(3, TweenAnimator.TweenType.Alpha, noRibbonsText.gameObject, 0.5f, 1f, 0f, 1, 0f);
		mAnimatorRibbonsEmpty.GenerateTweens();
		mAnimatorRibbons = base.gameObject.AddComponent<TweenAnimator>();
		mAnimatorRibbons.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimatorRibbons.AddTween(1, TweenAnimator.TweenType.Alpha, ribbonHeader.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimatorRibbons.GenerateTweens();
		mAnimatorSkillshotsHeaderSingle = base.gameObject.AddComponent<TweenAnimator>();
		mAnimatorSkillshotsHeaderSingle.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimatorSkillshotsHeaderSingle.AddTween(1, TweenAnimator.TweenType.Alpha, skillshotHeader.gameObject, 0.3f, 1f, 0.3f, -1, 0f);
		mAnimatorSkillshotsHeaderSingle.AddTween(2, TweenAnimator.TweenType.AlphaHider, playerObject, 0.5f, 1f, 0f, 1, 0f);
		mAnimatorSkillshotsHeaderSingle.GenerateTweens();
		mAnimatorSkillshotsHeaderMulti = base.gameObject.AddComponent<TweenAnimator>();
		mAnimatorSkillshotsHeaderMulti.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimatorSkillshotsHeaderMulti.AddTween(1, TweenAnimator.TweenType.Alpha, skillshotHeader.gameObject, 0.3f, 1f, 0.3f, -1, 0f);
		mAnimatorSkillshotsHeaderMulti.AddTween(2, TweenAnimator.TweenType.AlphaHider, playerObject, 0.5f, 1f, 0f, 1, 0f);
		mAnimatorSkillshotsHeaderMulti.AddTween(3, TweenAnimator.TweenType.AlphaHider, vsObject, 0.5f, 1f, 0f, 1, 0f);
		mAnimatorSkillshotsHeaderMulti.AddTween(4, TweenAnimator.TweenType.AlphaHider, opponentObject, 0.5f, 1f, 0f, 1, 0f);
		mAnimatorSkillshotsHeaderMulti.GenerateTweens();
		float num = (float)UIRoot.list[0].activeHeight / 2f;
		float num2 = 720f - num;
		topSpacer.transform.localPosition = topSpacer.transform.localPosition.ReplaceY(340f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(playerButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			TweenColor tweenColor = TweenColor.Begin(myIcon.nameLabel.gameObject, 0.2f, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(GameLoginManager.currentPlayer.name, GameLoginManager.currentPlayer.id);
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(GameLoginManager.currentPlayer.name, GameLoginManager.currentPlayer.id);
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(opponentButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (Singleton<GameController>.instance.isBattle)
			{
				TweenColor tweenColor = TweenColor.Begin(oponentIcon.nameLabel.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
				tweenColor.NumOfRepetitions = 2;
				tweenColor.style = UITweener.Style.PingPong;
				SoundsManager.Instance.PlayButtonClickedSound();
				if (Singleton<GameController>.instance.opponent.playerProperties.isBot)
				{
					GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(oponentIcon.nameLabel.text, Singleton<GameController>.instance.opponent.playerProperties.databaseInfoBot);
				}
				else
				{
					GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(oponentIcon.nameLabel.text, mOpponentPlayerId);
				}
			}
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(opponentIconButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (Singleton<GameController>.instance.isBattle)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				if (Singleton<GameController>.instance.opponent.playerProperties.isBot)
				{
					GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(oponentIcon.nameLabel.text, Singleton<GameController>.instance.opponent.playerProperties.databaseInfoBot);
				}
				else
				{
					GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(oponentIcon.nameLabel.text, mOpponentPlayerId);
				}
			}
		});
		gridSkillshot.onReposition = delegate
		{
			table.repositionNow = true;
		};
		table.onReposition = delegate
		{
			panelRibbons.AlignToPos(instant: true);
		};
	}

	internal void InitGuiValues()
	{
		mAnimator.Clear();
		string text = "Ribbon Bug Passed ";
		try
		{
			text += " 0";
			FillRibbonsTable(Singleton<ScoreManager>.instance.skillShotCounts);
			text += " 1";
			InitializeSkillshotHeader();
			text += " 2";
			CreateSkillshotRecords();
			text += " 3";
			CreateSkillshotAnimations();
			text += " 4";
		}
		catch (Exception ex)
		{
			Debug.LogError($"{text}\n{ex.StackTrace}");
			Crittercism.LogHandledException(ex);
		}
	}

	public void AnimateShow(float fadeInTime)
	{
	}

	private void FillRibbonsTable(Dictionary<SkillShot.SkillShotType, int> skillshots)
	{
		gainedRibbons.gameObject.SetActive(value: true);
		gainedRibbons.MakeEmpty();
		mDisplayedRibbons.Clear();
		ribbonHeader.alpha = 0f;
		Dictionary<RibbonManager.RibbonItemDefinition, int> ribbons = Singleton<RibbonManager>.instance.GetRibbons(skillshots);
		int num = 0;
		if (ribbons == null || ribbons.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<RibbonManager.RibbonItemDefinition, int> item in ribbons)
		{
			num += item.Value * item.Key.warbucks;
			int value = item.Value;
			if (value > 0)
			{
				mDisplayedRibbons.Add(new Tuple<RibbonManager.RibbonItemDefinition, int>(item.Key, value));
			}
		}
		if (mDisplayedRibbons.Count == 0)
		{
			mAnimator.Add(mAnimatorRibbonsEmpty);
			noRibbonsGained.SetActive(value: true);
			noRibbonsBackground.alpha = 0f;
			noRibbonsText.alpha = 0f;
			gainedRibbons.gameObject.SetActive(value: false);
		}
		else
		{
			mAnimator.Add(mAnimatorRibbons);
			noRibbonsGained.SetActive(value: false);
			gainedRibbons.init(mDisplayedRibbons.Count, GetRibbonTransform, FreeRibbonTransform, panelRibbons);
		}
	}

	private Transform GetRibbonTransform(int index)
	{
		if (index >= 0 && index < mDisplayedRibbons.Count && mPool != null)
		{
			RibbonGuiRecord ribbonGuiRecord = (RibbonGuiRecord)mPool.InstantiateAsChild(ribbonGuiRecordPrefab, gainedRibbons.gameObject, $"Ribbon {index}");
			if (ribbonGuiRecord != null)
			{
				ribbonGuiRecord.Initialize(mDisplayedRibbons[index].Value1, mDisplayedRibbons[index].Value2);
				return ribbonGuiRecord.transform;
			}
		}
		return null;
	}

	private void FreeRibbonTransform(Transform obj)
	{
		if (obj != null)
		{
			RibbonGuiRecord component = obj.GetComponent<RibbonGuiRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void InitializeSkillshotHeader()
	{
		TweenAlphaHider.Begin(playerObject, 0.01f, 0f);
		TweenAlphaHider.Begin(vsObject, 0.01f, 0f);
		TweenAlphaHider.Begin(opponentObject, 0.01f, 0f);
		skillshotHeader.alpha = 0f;
		mOpponentPlayerId = string.Empty;
		bool flag = false;
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		if (Singleton<GameController>.instance.isTutorial || Singleton<GameController>.instance.isCampaignBot || Singleton<GameController>.instance.isCoopBot)
		{
			flag = false;
		}
		if (Singleton<GameController>.instance.isBattle)
		{
			mOpponentPlayerId = opponent.playerProperties.playerID;
			flag = true;
		}
		myIcon.avatar = Singleton<ArmyPreviewCamera>.instance.player1Texture;
		myIcon.SetName(GameLoginManager.currentPlayer.name);
		TweenColor.Begin(myIcon.nameLabel.gameObject, 0f, Color.white);
		opponentCollider.enabled = flag;
		if (!mIsSinglePlayer)
		{
			oponentIcon.Reset();
			oponentIcon.avatar = Singleton<ArmyPreviewCamera>.instance.player2Texture;
			oponentIcon.SetName((!(opponent == null)) ? opponent.playerProperties.name : string.Empty);
			TweenColor.Begin(oponentIcon.nameLabel.gameObject, 0f, Color.white);
		}
		mAnimator.Add((!mIsSinglePlayer) ? mAnimatorSkillshotsHeaderMulti : mAnimatorSkillshotsHeaderSingle);
	}

	private void CreateSkillshotRecords()
	{
		if (mPool == null)
		{
			mPool = Singleton<GuiManager>.instance.objectPool;
		}
		mPool.FreeObjectsWithPrefab(skillshotGuiRecordPrefab);
		if (mSkillshotRecords != null)
		{
			mSkillshotRecords.Clear();
		}
		else
		{
			mSkillshotRecords = new List<SkillshotGuiRecord>();
		}
		if (mIsSinglePlayer)
		{
			CreateSkillshotRecordsSinglePlayer();
		}
		else
		{
			CreateSkillshotRecordsMultiplayer();
		}
		gridSkillshot.repositionNow = true;
	}

	private void CreateSkillshotRecordsMultiplayer()
	{
		SkillshotGuiRecord skillshotGuiRecord = (SkillshotGuiRecord)mPool.InstantiateAsChild(skillshotGuiRecordPrefab, gridSkillshot.gameObject, "Skillshot 0000");
		if (skillshotGuiRecord != null)
		{
			skillshotGuiRecord.MultiplayerSkillshotSpecial(Singleton<ScoreManager>.instance.score, Singleton<ScoreManager>.instance.opponentScore);
			mSkillshotRecords.Add(skillshotGuiRecord);
		}
		int num = 1;
		Dictionary<SkillShot.SkillShotType, int> skillShotCounts = Singleton<ScoreManager>.instance.skillShotCounts;
		if (skillShotCounts == null)
		{
			return;
		}
		foreach (KeyValuePair<SkillShot.SkillShotType, int> item in skillShotCounts)
		{
			int opponentCount = (Singleton<ScoreManager>.instance.skillShotCountsOponent.ContainsKey(item.Key) ? Singleton<ScoreManager>.instance.skillShotCountsOponent[item.Key] : 0);
			SkillshotGuiRecord skillshotGuiRecord2 = (SkillshotGuiRecord)mPool.InstantiateAsChild(skillshotGuiRecordPrefab, gridSkillshot.gameObject, string.Format("Skillshot {0}", num++.ToString("D4")));
			if (skillshotGuiRecord2 != null)
			{
				skillshotGuiRecord2.MultiplayerSkillshot(item.Value, opponentCount, item.Key);
				mSkillshotRecords.Add(skillshotGuiRecord2);
			}
		}
	}

	private void CreateSkillshotRecordsSinglePlayer()
	{
		SkillshotGuiRecord skillshotGuiRecord = (SkillshotGuiRecord)mPool.InstantiateAsChild(skillshotGuiRecordPrefab, gridSkillshot.gameObject, "Skillshot 0000");
		if (skillshotGuiRecord != null)
		{
			skillshotGuiRecord.SingleplayerSkillshotSpecial(Singleton<ScoreManager>.instance.score);
			mSkillshotRecords.Add(skillshotGuiRecord);
		}
		int num = 1;
		Dictionary<SkillShot.SkillShotType, int> skillShotCounts = Singleton<ScoreManager>.instance.skillShotCounts;
		if (skillShotCounts == null)
		{
			return;
		}
		foreach (KeyValuePair<SkillShot.SkillShotType, int> item in skillShotCounts)
		{
			SkillshotGuiRecord skillshotGuiRecord2 = (SkillshotGuiRecord)mPool.InstantiateAsChild(skillshotGuiRecordPrefab, gridSkillshot.gameObject, string.Format("Skillshot {0}", num++.ToString("D4")));
			if (skillshotGuiRecord2 != null)
			{
				skillshotGuiRecord2.SingleplayerSkillshot(item.Value, item.Key);
				mSkillshotRecords.Add(skillshotGuiRecord2);
			}
		}
	}

	private void CreateSkillshotAnimations()
	{
		if (mAnimatorSkillshots == null)
		{
			mAnimatorSkillshots = base.gameObject.AddComponent<TweenAnimator>();
		}
		if (mAnimatorSkillshots.allTweens == null)
		{
			mAnimatorSkillshots.allTweens = new List<TweenAnimator.TweenRecord>();
		}
		else
		{
			mAnimatorSkillshots.allTweens.Clear();
		}
		int num = 0;
		float num2 = 0.5f;
		foreach (SkillshotGuiRecord mSkillshotRecord in mSkillshotRecords)
		{
			num++;
			num2 += 0.2f;
			int num3 = num * 100;
			int playAfterIdFinished;
			if (mSkillshotRecord.isSpecial)
			{
				mSkillshotRecord.HideAll();
				mSkillshotRecord.bar.fillAmount = 0f;
				mSkillshotRecord.whiteBar.fillAmount = 0f;
				mSkillshotRecord.playerScore.text = "x0";
				mAnimatorSkillshots.AddTween(num3 + 1, TweenAnimator.TweenType.Alpha, mSkillshotRecord.playerBackground.gameObject, 0.5f, 1f, num2, -1, 0f);
				mAnimatorSkillshots.AddTween(num3 + 3, TweenAnimator.TweenType.Alpha, mSkillshotRecord.playerScore.gameObject, 0.5f, 1f, num2, -1, 0f);
				mAnimatorSkillshots.AddTween(num3 + 5, TweenAnimator.TweenType.Alpha, mSkillshotRecord.skillshotType.gameObject, 0.5f, 1f, num2, -1, 0f);
				mAnimatorSkillshots.AddTween(num3 + 6, TweenAnimator.TweenType.Alpha, mSkillshotRecord.backgroundBar.gameObject, 0.5f, 1f, num2, -1, 0f);
				mAnimatorSkillshots.AddTween(num3 + 7, TweenAnimator.TweenType.Alpha, mSkillshotRecord.whiteBar.gameObject, 0.5f, 1f, num2, -1, 0f);
				mAnimatorSkillshots.AddTween(num3 + 8, TweenAnimator.TweenType.Alpha, mSkillshotRecord.bar.gameObject, 0.5f, 1f, num2, -1, 0f);
				if (!mIsSinglePlayer)
				{
					mAnimatorSkillshots.AddTween(num3 + 9, TweenAnimator.TweenType.Alpha, mSkillshotRecord.opponentBackground.gameObject, 0.5f, 1f, num2, -1, 0f);
				}
				mAnimatorSkillshots.AddTween(num3 + 10, TweenAnimator.TweenType.Alpha, mSkillshotRecord.opponentScore.gameObject, 0.5f, 1f, num2, -1, 0f);
				mAnimatorSkillshots.AddTween(from: new FloatObject(0f), id: num3 + 12, tweenType: TweenAnimator.TweenType.ProgressBar, tweenTarget: mSkillshotRecord.whiteBar.gameObject, time: 0.2f, to: new FloatObject(mSkillshotRecord.plProgress), delay: 0f, playAfterIdFinished: num3 + 1);
				mAnimatorSkillshots.AddTween(from: new FloatObject(0f), id: num3 + 13, tweenType: TweenAnimator.TweenType.ProgressBar, tweenTarget: mSkillshotRecord.bar.gameObject, time: 0.2f, to: new FloatObject(mSkillshotRecord.plProgress), delay: 0f, playAfterIdFinished: num3 + 12);
				TweenAnimator tweenAnimator = mAnimatorSkillshots;
				playAfterIdFinished = num3 + 1;
				tweenAnimator.AddTween(num3 + 14, TweenAnimator.TweenType.TextCounterSpecial, mSkillshotRecord.playerScore.gameObject, 0.4f, new IntObject(mSkillshotRecord.plScore), 0f, playAfterIdFinished);
				if (!mIsSinglePlayer)
				{
					if (mSkillshotRecord.plScore > mSkillshotRecord.opScore)
					{
						mAnimatorSkillshots.AddTween(num3 + 16, TweenAnimator.TweenType.Alpha, mSkillshotRecord.playerWin.gameObject, 0.5f, 1f, 0f, num3 + 12, 0f);
					}
					else if (mSkillshotRecord.opScore > mSkillshotRecord.plScore)
					{
						mAnimatorSkillshots.AddTween(num3 + 16, TweenAnimator.TweenType.Alpha, mSkillshotRecord.opponentWin.gameObject, 0.5f, 1f, 0f, num3 + 12, 0f);
					}
				}
				continue;
			}
			mSkillshotRecord.HideAll();
			mSkillshotRecord.bar.fillAmount = 0f;
			mSkillshotRecord.whiteBar.fillAmount = 0f;
			mSkillshotRecord.playerModifier.text = "+0";
			mSkillshotRecord.playerScore.text = "x0";
			mAnimatorSkillshots.AddTween(num3 + 1, TweenAnimator.TweenType.Alpha, mSkillshotRecord.playerBackground.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(num3 + 2, TweenAnimator.TweenType.Alpha, mSkillshotRecord.playerScore.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(num3 + 3, TweenAnimator.TweenType.Alpha, mSkillshotRecord.playerModifier.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(num3 + 4, TweenAnimator.TweenType.Alpha, mSkillshotRecord.skillshotIcon.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(num3 + 5, TweenAnimator.TweenType.Alpha, mSkillshotRecord.skillshotType.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(num3 + 6, TweenAnimator.TweenType.Alpha, mSkillshotRecord.backgroundBar.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(num3 + 7, TweenAnimator.TweenType.Alpha, mSkillshotRecord.whiteBar.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(num3 + 8, TweenAnimator.TweenType.Alpha, mSkillshotRecord.bar.gameObject, 0.5f, 1f, num2, -1, 0f);
			if (!mIsSinglePlayer)
			{
				mAnimatorSkillshots.AddTween(num3 + 9, TweenAnimator.TweenType.Alpha, mSkillshotRecord.opponentBackground.gameObject, 0.5f, 1f, num2, -1, 0f);
			}
			mAnimatorSkillshots.AddTween(num3 + 10, TweenAnimator.TweenType.Alpha, mSkillshotRecord.opponentScore.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(num3 + 11, TweenAnimator.TweenType.Alpha, mSkillshotRecord.opponentModifier.gameObject, 0.5f, 1f, num2, -1, 0f);
			mAnimatorSkillshots.AddTween(from: new FloatObject(0f), id: num3 + 12, tweenType: TweenAnimator.TweenType.ProgressBar, tweenTarget: mSkillshotRecord.whiteBar.gameObject, time: 0.2f, to: new FloatObject(mSkillshotRecord.plProgress), delay: 0f, playAfterIdFinished: num3 + 1);
			mAnimatorSkillshots.AddTween(from: new FloatObject(0f), id: num3 + 13, tweenType: TweenAnimator.TweenType.ProgressBar, tweenTarget: mSkillshotRecord.bar.gameObject, time: 0.2f, to: new FloatObject(mSkillshotRecord.plProgress), delay: 0f, playAfterIdFinished: num3 + 12);
			TweenAnimator tweenAnimator2 = mAnimatorSkillshots;
			playAfterIdFinished = num3 + 1;
			tweenAnimator2.AddTween(num3 + 14, TweenAnimator.TweenType.TextCounter, mSkillshotRecord.playerScore.gameObject, 0.4f, new IntObject(mSkillshotRecord.plScore), 0f, playAfterIdFinished);
			TweenAnimator tweenAnimator3 = mAnimatorSkillshots;
			playAfterIdFinished = num3 + 1;
			tweenAnimator3.AddTween(num3 + 15, TweenAnimator.TweenType.TextCounter, mSkillshotRecord.playerModifier.gameObject, 0.4f, new IntObject(mSkillshotRecord.plModifier), 0f, playAfterIdFinished);
			if (!mIsSinglePlayer)
			{
				if (mSkillshotRecord.plScore > mSkillshotRecord.opScore)
				{
					mAnimatorSkillshots.AddTween(num3 + 16, TweenAnimator.TweenType.Alpha, mSkillshotRecord.playerWin.gameObject, 0.5f, 1f, 0f, num3 + 12, 0f);
				}
				else if (mSkillshotRecord.opScore > mSkillshotRecord.plScore)
				{
					mAnimatorSkillshots.AddTween(num3 + 16, TweenAnimator.TweenType.Alpha, mSkillshotRecord.opponentWin.gameObject, 0.5f, 1f, 0f, num3 + 12, 0f);
				}
			}
		}
		mAnimatorSkillshots.GenerateTweens();
		mAnimator.Add(mAnimatorSkillshots);
	}

	internal void ResetAnimation()
	{
		foreach (TweenAnimator item in Animator)
		{
			item.ResetTweens();
		}
	}

	internal void FinishAnimation()
	{
		foreach (TweenAnimator item in Animator)
		{
			item.FinishTweens();
		}
	}

	public void DoAfterHide()
	{
		gainedRibbons.MakeEmpty();
		mPool.FreeObjectsWithPrefab(skillshotGuiRecordPrefab);
	}
}
