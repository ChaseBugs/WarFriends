using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DailyRewardMonthScreen : GuiScreenSingle<DailyRewardMonthScreen>
{
	public class DailyRewardSerwerData
	{
		public Action dataUpdated;

		public int month;

		public int year;

		public List<DailyRewardDataForDay> dayRewards;

		public int lastClaimed;

		public int toClaim;

		private int mNextMidnight;

		public bool canClaim => lastClaimed < toClaim;

		public int totalDays => dayRewards.Count;

		public DailyRewardDataForDay this[int index] => dayRewards[index - 1];

		public bool canNotification => lastClaimed == toClaim;

		public DailyRewardSerwerData(JToken data)
		{
			UpdateFromData(data);
		}

		public string GetLocalPushNotificationText(bool useUnknownReward = false)
		{
			string text = Localization.Localize("ID_NOTIFICATION_DAILYREWARD_UNKNOWN");
			if (useUnknownReward)
			{
				return Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_MESSAGE", text);
			}
			if (dayRewards.Count > toClaim)
			{
				switch (dayRewards[toClaim].rewardType)
				{
				case DailyReward.ArenaTickets:
					text = Localization.Localize("ID_NOTIFICATION_DAILYREWARD_TICKET");
					break;
				case DailyReward.BronzeCardpack:
				case DailyReward.SilverCardpack:
				case DailyReward.GoldCardpack:
					text = Localization.Localize("ID_NOTIFICATION_DAILYREWARD_CARDPACK");
					break;
				case DailyReward.Vip:
					text = Localization.Localize("ID_NOTIFICATION_DAILYREWARD_VIP");
					break;
				case DailyReward.Customization:
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(dayRewards[toClaim].parameters);
					if (visual != null)
					{
						text = visual.name;
					}
					else
					{
						Debug.Log("null customization for: " + dayRewards[toClaim].parameters);
					}
					break;
				}
				case DailyReward.PowerBand:
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(dayRewards[toClaim].parameters);
					if (powerBand != null)
					{
						text = powerBand.name;
					}
					else
					{
						Debug.Log("null powerband for: " + dayRewards[toClaim].parameters);
					}
					break;
				}
				case DailyReward.Gold:
					text = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_GOLD", MiscTools.FormatBigNumberLong(dayRewards[toClaim].count));
					break;
				case DailyReward.Warbucks:
					text = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_WB", MiscTools.FormatBigNumberLong(dayRewards[toClaim].count));
					break;
				case DailyReward.BronzeCards:
				case DailyReward.SilverCards:
				case DailyReward.GoldCards:
				case DailyReward.ParticularCards:
					text = ((dayRewards[toClaim].count != 1) ? Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_CARDS", MiscTools.FormatBigNumberLong(dayRewards[toClaim].count)) : Localization.Localize("ID_NOTIFICATION_DAILYREWARD_CARD"));
					break;
				}
			}
			return Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_MESSAGE", text);
		}

		public void CheckDownloadNext()
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > mNextMidnight)
			{
				mNextMidnight += 300;
				Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
			}
		}

		public void UpdateFromData(JToken data)
		{
			month = StringParser.ParseIntToken(data["month"]);
			year = StringParser.ParseIntToken(data["year"]);
			toClaim = StringParser.ParseIntToken(data["canClaim"]);
			lastClaimed = StringParser.ParseIntToken(data["claimReward"]);
			int num = StringParser.ParseIntToken(data["nextDay"]);
			mNextMidnight = Singleton<BeanstalkServerManager>.instance.currentTimestamp + num;
			JToken jToken = data["config"];
			int num2 = 1;
			JToken jToken2 = null;
			try
			{
				jToken2 = jToken[num2.ToString("'Day'0")];
			}
			catch (Exception ex)
			{
				Debug.LogError("ERROR WRONG DAILY REWARDS: " + jToken);
				Debug.LogError("EXCEPTION = " + ex);
			}
			if (dayRewards == null)
			{
				dayRewards = new List<DailyRewardDataForDay>();
			}
			while (jToken2 != null)
			{
				if (dayRewards.Count >= num2)
				{
					dayRewards[num2 - 1].updateFromData(jToken2);
				}
				else
				{
					dayRewards.Add(new DailyRewardDataForDay(jToken2));
				}
				num2++;
				jToken2 = jToken[num2.ToString("'Day'0")];
			}
			while (dayRewards.Count >= num2)
			{
				dayRewards.RemoveAt(dayRewards.Count - 1);
			}
			if (canNotification)
			{
				bool useUnknownReward = Singleton<BeanstalkServerManager>.instance.currentDateTime.Day == DateTime.DaysInMonth(year, month);
				PushNotificationManager.instance.ScheduleDailyRewardNotification(mNextMidnight, GetLocalPushNotificationText(useUnknownReward));
			}
			else
			{
				PushNotificationManager.instance.ScheduleDailyRewardNotification(0, string.Empty);
			}
			if (dataUpdated != null)
			{
				dataUpdated();
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}/{1} ({2})\n", month, year, dayRewards.Count);
			stringBuilder.AppendFormat("last {0} and can now {1} ({2})\n", lastClaimed, toClaim, canClaim);
			stringBuilder.AppendLine(GetLocalPushNotificationText());
			for (int i = 0; i < dayRewards.Count; i++)
			{
				stringBuilder.AppendFormat("day {0} data:\n", i + 1);
				stringBuilder.AppendLine(dayRewards[i].ToString());
			}
			return stringBuilder.ToString();
		}
	}

	public class DailyRewardDataForDay
	{
		public DailyReward rewardType;

		public DailyRewardDouble doubleFor;

		public string parameters;

		public long count;

		public DailyRewardDataForDay(DailyReward type, long value)
		{
			rewardType = type;
			count = value;
		}

		public DailyRewardDataForDay(JToken data)
		{
			updateFromData(data);
		}

		public void updateFromData(JToken data)
		{
			rewardType = (DailyReward)StringParser.ParseIntToken(data["Type"]);
			doubleFor = (DailyRewardDouble)StringParser.ParseIntToken(data["Double"]);
			count = StringParser.ParseLongToken(data["Count"], 0L);
			parameters = null;
			parameters = data["Param"].ToString();
		}

		public override string ToString()
		{
			return string.Format("  {1}x{0} ( {3} ) doubled for: {2}", rewardType, count, doubleFor, (!string.IsNullOrEmpty(parameters)) ? parameters : "no parameters");
		}
	}

	[Header("Info")]
	public bool showedFromDialog;

	[Header("Header")]
	public GameObject xButton;

	public UILabel titleText;

	public UILabel subtitleText;

	[Header("List Of Rewards")]
	public UIPooledGrid grid;

	public DailyRewardMonthButton rewardButtonPrefab;

	public UIDraggablePanel dragPanel;

	public CameraPanelAligner cpA;

	[Header("Bottom Button")]
	public BoxCollider claimButtonColider;

	public UILabel claimButtonText;

	public GameObject claimButtonHighlight;

	public UISprite claimButtonBG;

	public Transform buttonHighlight;

	[Header("Warcard Animation")]
	public CardMenuOwerlay cardOverlay;

	[Header("Debug")]
	public GameObject changeDateContent;

	public UIInput changeDay;

	public UIInput changeMonth;

	public UIInput changeYeay;

	public GameObject changeDateButton;

	private DailyRewardSerwerData mShowedFor;

	private ObjectPool mPool;

	private bool mCanChange = true;

	private float mUnlockTime;

	private TweenPosition mTweenPosition;

	private Vector3 mOffScreenPos = new Vector3(500f, 155f, 0f);

	private Vector3 mInScreenPos = new Vector3(-245f, 155f, 0f);

	private int mLastSelected = -1;

	private bool mNeedChange;

	private bool mIsFirstSet;

	private RadicalRoutine mAutomaticClose;

	private bool mNeedButtonChange
	{
		get
		{
			int num = mLastSelected - mShowedFor.toClaim;
			int num2 = mShowedFor.totalDays - DateTime.Now.Day + mShowedFor.toClaim;
			if (mLastSelected > num2)
			{
				return claimButtonText.text != Localization.Localize("ID_NOLONGERAVAILABLE");
			}
			if (mShowedFor.canClaim && mLastSelected == mShowedFor.toClaim)
			{
				return claimButtonText.text != Localization.Localize("ID_CLAIM");
			}
			if (mLastSelected <= mShowedFor.lastClaimed)
			{
				return claimButtonText.text != Localization.Localize("ID_CLAIMED");
			}
			if (num == 1)
			{
				return claimButtonText.text != Localization.Localize("ID_TOMORROW");
			}
			return claimButtonText.text != Localization.LocalizeFormat("ID_LOGININDAYS", num);
		}
	}

	protected override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(claimButtonColider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ClaimButtonClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(xButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GoBackClick));
	}

	private void ClaimButtonClicked(GameObject go)
	{
		if (mLastSelected == mShowedFor.toClaim && mShowedFor.canClaim)
		{
			mShowedFor.lastClaimed = mShowedFor.toClaim;
			ChangeButtonRutine();
			titleText.text = Localization.Localize("ID_COMEBACKTOMORROW");
			MiscTools.SetUILabelRescale(titleText, 84f, 42f, (int)UIRoot.list[0].activeWidth - 250);
			subtitleText.text = Localization.LocalizeFormat("ID_REWARDSCLAIMEDCAMEBACKEVERYDAY", mShowedFor.lastClaimed, mShowedFor.totalDays, Localization.Localize(mShowedFor.month.ToString("'ID_MONTH_'0")));
			MiscTools.SetUILabelRescale(subtitleText, 33f, 20f, (int)UIRoot.list[0].activeWidth - 250);
			Transform itemOnIndex = grid.GetItemOnIndex(mLastSelected - 1);
			if (itemOnIndex != null)
			{
				itemOnIndex.GetComponent<DailyRewardMonthButton>().AnimateClaim();
			}
			AutomaticBack();
			mCanChange = false;
			mUnlockTime = Time.time + 3f;
			Singleton<BeanstalkServerManager>.instance.claimDailyReward(mLastSelected);
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.DailyRewardClaim);
		}
	}

	public void GoBackClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<GuiManager>.instance.ShowGui((!(base.previousScreen != null)) ? GuiScreenSingle<MainScreen>.instance : base.previousScreen);
		}
	}

	public void AutomaticBack()
	{
		StopAutomaticBackCoroutine();
		mAutomaticClose = RadicalRoutine.Create(AutomaticBackWait());
		StartCoroutine(RadicalRoutine.Run(mAutomaticClose.enumerator));
	}

	private void StopAutomaticBackCoroutine()
	{
		if (mAutomaticClose != null)
		{
			mAutomaticClose.Cancel();
			mAutomaticClose = null;
		}
	}

	private IEnumerator AutomaticBackWait(bool isLeft = false)
	{
		bool goBack = true;
		while (claimButtonText.text != Localization.Localize("ID_CLAIMED") || claimButtonColider.transform.localPosition != mInScreenPos || cardOverlay.gameObject.activeSelf)
		{
			if (claimButtonText.text != Localization.Localize("ID_CLAIM") && claimButtonText.text != Localization.Localize("ID_CLAIMING") && claimButtonText.text != Localization.Localize("ID_CLAIMED"))
			{
				goBack = false;
				break;
			}
			yield return new WaitForRealSeconds(0.1f);
		}
		if (goBack)
		{
			GoBackClick(xButton);
		}
	}

	private void ChangeButtonRutine()
	{
		mTweenPosition = TweenPosition.Begin(claimButtonColider.gameObject, 0.2f, mOffScreenPos);
		TweenPosition tweenPosition = mTweenPosition;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(ShowButtonToScreen));
		TweenPosition tweenPosition2 = mTweenPosition;
		tweenPosition2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition2.onFinished, new UITweener.OnFinished(ShowButtonToScreen));
	}

	private void ShowButtonToScreen(UITweener tw)
	{
		SetButtonByActual();
		mTweenPosition = TweenPosition.Begin(claimButtonColider.gameObject, 0.2f, mInScreenPos);
		TweenPosition tweenPosition = mTweenPosition;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Remove(tweenPosition.onFinished, new UITweener.OnFinished(ShowButtonToScreen));
	}

	private void ChangeSelected(int index)
	{
		if (mLastSelected == index)
		{
			ClaimButtonClicked(null);
			return;
		}
		mLastSelected = index;
		Vector3 positionForIndex = grid.getPositionForIndex(index - 1);
		buttonHighlight.localPosition = positionForIndex;
		ChangeButtonRutine();
		Vector3 localScale = new Vector3(1.2f, 1.2f, 1f);
		Vector3 scale = new Vector3(1.05f, 1.05f, 1f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(buttonHighlight.GetChild(0).gameObject, 0.3f, 0f, 1f);
		tweenAlpha.alpha = 0f;
		buttonHighlight.localScale = localScale;
		TweenScale.Begin(buttonHighlight.gameObject, 0.3f, scale);
	}

	private void SetButtonByActual()
	{
		int num = mLastSelected - mShowedFor.toClaim;
		int num2 = mShowedFor.totalDays - DateTime.Now.Day + mShowedFor.toClaim;
		if (mLastSelected > num2)
		{
			SetButtonNot(Localization.Localize("ID_NOLONGERAVAILABLE"));
			return;
		}
		if (mShowedFor.canClaim && mLastSelected == mShowedFor.toClaim)
		{
			SetButtonToClaim();
			return;
		}
		if (!mCanChange && mLastSelected == mShowedFor.toClaim)
		{
			SetButtonNot(Localization.Localize("ID_CLAIMING"));
			return;
		}
		if (mLastSelected <= mShowedFor.lastClaimed)
		{
			SetButtonNot(Localization.Localize("ID_CLAIMED"));
			return;
		}
		if (num == 1)
		{
			SetButtonNot(Localization.Localize("ID_TOMORROW"));
			return;
		}
		SetButtonNot(Localization.LocalizeFormat("ID_LOGININDAYS", num));
	}

	private void SetButtonToClaim()
	{
		claimButtonColider.enabled = true;
		claimButtonHighlight.SetActive(value: true);
		claimButtonText.text = Localization.Localize("ID_CLAIM");
		claimButtonText.color = Color.black;
		MiscTools.SetUILabelRescale(claimButtonText, 66f, 33f, 450);
		claimButtonBG.spriteName = "menu-button-oneside";
		claimButtonBG.color = Color.white;
	}

	private void SetButtonNot(string text, float size = 66f)
	{
		claimButtonColider.enabled = false;
		claimButtonHighlight.SetActive(value: false);
		claimButtonText.text = text;
		claimButtonText.color = Color.white;
		MiscTools.SetUILabelRescale(claimButtonText, 66f, 33f, 450);
		claimButtonBG.spriteName = "menu-button-oneside-white";
		claimButtonBG.color = Colours.blackHalfTransparent;
	}

	private Transform InstantinateByIndex(int index)
	{
		if (mShowedFor != null && mShowedFor.totalDays > index && index >= 0)
		{
			DailyRewardMonthButton dailyRewardMonthButton = (DailyRewardMonthButton)mPool.InstantiateAsChild(rewardButtonPrefab, grid.gameObject, (index + 1).ToString("'RewardForDay_'0"));
			if (dailyRewardMonthButton != null)
			{
				int lastClaimableIndex = mShowedFor.totalDays - DateTime.Now.Day + mShowedFor.toClaim;
				dailyRewardMonthButton.SetForData(index + 1, mShowedFor.dayRewards[index], mShowedFor.toClaim, mShowedFor.canClaim, ChangeSelected, lastClaimableIndex);
				return dailyRewardMonthButton.transform;
			}
		}
		return null;
	}

	private void MakeItemFree(Transform obj)
	{
		DailyRewardMonthButton component = obj.GetComponent<DailyRewardMonthButton>();
		if (component != null)
		{
			component.DestroyPooled();
		}
	}

	private void DataChanged()
	{
		if (!mCanChange)
		{
			mNeedChange = true;
			return;
		}
		mNeedChange = false;
		DailyRewardSerwerData dailyRewardSerwerData = mShowedFor;
		dailyRewardSerwerData.dataUpdated = (Action)Delegate.Remove(dailyRewardSerwerData.dataUpdated, new Action(DataChanged));
		int num = mLastSelected;
		InitGUIValues();
		if (mShowedFor.totalDays < num)
		{
			mLastSelected = -1;
			ChangeSelected(mShowedFor.toClaim);
		}
		else if (mNeedButtonChange)
		{
			ChangeButtonRutine();
		}
		dragPanel.RestrictWithinBounds(instant: false);
	}

	private void SetDebugButtons()
	{
		changeDateContent.SetActive(DebugSettings.debugEnabled);
	}

	public override void InitGUIValues()
	{
		base.previousScreen = GuiScreenSingle<MainScreen>.instance;
		SetDebugButtons();
		if (!mIsFirstSet)
		{
			float activeWidth = UIRoot.list[0].activeWidth;
			float num;
			for (num = activeWidth - 1920f; num > grid.cellWidth - 20f; num -= grid.cellWidth)
			{
				grid.maxPerLine++;
			}
			for (; num < -20f; num += grid.cellWidth)
			{
				grid.maxPerLine--;
			}
			float num2 = num * 0.5f;
			UIPanel panel = dragPanel.panel;
			cpA.panel = panel;
			cpA.basePosition.x += num2;
			cpA.Align();
			cpA.panel = panel;
			mIsFirstSet = true;
		}
		if (mPool == null)
		{
			mPool = Singleton<GuiManager>.instance.objectPool;
		}
		mShowedFor = StatsManager.instance.dailyRewardData;
		DailyRewardSerwerData dailyRewardSerwerData = mShowedFor;
		dailyRewardSerwerData.dataUpdated = (Action)Delegate.Combine(dailyRewardSerwerData.dataUpdated, new Action(DataChanged));
		Debug.Log("DailyRewardMonthScreen: init gui vlaues called");
		if (mShowedFor != null)
		{
			titleText.text = Localization.LocalizeFormat("ID_LOGINREWARDS", Localization.Localize(mShowedFor.month.ToString("'ID_MONTH_'0")).ToUpper());
			MiscTools.SetUILabelRescale(titleText, 84f, 42f, (int)UIRoot.list[0].activeWidth - 250);
			subtitleText.text = Localization.LocalizeFormat("ID_REWARDSCLAIMEDCAMEBACKEVERYDAY", mShowedFor.lastClaimed, mShowedFor.totalDays, Localization.Localize(mShowedFor.month.ToString("'ID_MONTH_'0")));
			MiscTools.SetUILabelRescale(subtitleText, 33f, 20f, (int)UIRoot.list[0].activeWidth - 250);
			grid.MakeEmpty();
			grid.init(mShowedFor.totalDays, InstantinateByIndex, MakeItemFree, dragPanel);
			changeDay.text = "1";
			changeMonth.text = mShowedFor.month.ToString();
			changeYeay.text = mShowedFor.year.ToString();
		}
	}

	public override void DoBeforeShowUp()
	{
		cardOverlay.ResetDraw();
		base.DoBeforeShowUp();
		StopAutomaticBackCoroutine();
		mCanChange = true;
		claimButtonColider.transform.localPosition = mInScreenPos;
		if (showedFromDialog)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.DailyRewardShow);
		}
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		if (mShowedFor != null)
		{
			dragPanel.AlignToCenter(grid.getPositionForIndex(mShowedFor.toClaim - 1), instant: true);
			mLastSelected = -1;
			ChangeSelected(mShowedFor.toClaim);
		}
		else
		{
			dragPanel.AlignToPos(instant: true);
		}
		grid.PositionChanged();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mShowedFor != null)
		{
			DailyRewardSerwerData dailyRewardSerwerData = mShowedFor;
			dailyRewardSerwerData.dataUpdated = (Action)Delegate.Remove(dailyRewardSerwerData.dataUpdated, new Action(DataChanged));
		}
		showedFromDialog = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		grid.MakeEmpty();
		StopAutomaticBackCoroutine();
	}

	public void ShowCards(string[] cardNames, int mult)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		Card[] array = new Card[cardNames.Length * mult];
		for (int i = 0; i < cardNames.Length; i++)
		{
			Card cardInstance = CardManager.instance.GetCardInstance(cardNames[i]);
			for (int j = 0; j < mult; j++)
			{
				array[i * mult + j] = cardInstance;
			}
		}
		cardOverlay.StartShowAnimation(array, 0.5f, canHideImmediately: false);
	}

	protected override void Update()
	{
		base.Update();
		if (!mCanChange && mUnlockTime < Time.time)
		{
			mCanChange = true;
			if (mNeedChange)
			{
				DataChanged();
			}
		}
	}
}
