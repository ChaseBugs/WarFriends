using System;
using System.Collections.Generic;
using UnityEngine;

public class SquadCardpoolContent : Core_BaseScript
{
	[Header("Core")]
	public UIPanel panelMain;

	public GameObject topCenterGO;

	public GameObject topRightGO;

	[Header("Header")]
	public GameObject depositWarcards;

	public UITable leftTopTable;

	public UILabel reputationPointsLabel;

	public UITable withdrawTable;

	public UILabel firstTextWithdraw;

	public UIPanel counterPanel;

	public WinStreakCounter withdrawAvailable;

	public GameObject lastSpacerGO;

	[Header("List")]
	public UIPanel panel;

	public UIDraggablePanel draggablePanel;

	public UIPooledGrid cardpoolGrid;

	public CardpoolRecord cardpoolRecordPrefab;

	[Header("Waiting for server")]
	public UISprite waitingSprite;

	private bool mIsActive;

	private List<DatabasePlayer> mMemberRecords = new List<DatabasePlayer>();

	private Dictionary<string, int> mNotificationRestriction = new Dictionary<string, int>();

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		mIsActive = false;
		UIEventListener uIEventListener = UIEventListener.Get(depositWarcards);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DepositClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		CardManager.instance.WithdrawTimeChanged += OnWithdrawTimeChanged;
		int num = 134;
		float activeWidth = UIRoot.list[0].activeWidth;
		int num2 = UIRoot.list[0].activeHeight - (470 + num);
		topCenterGO.transform.localPosition = new Vector3(activeWidth / 2f - 60f, topCenterGO.transform.localPosition.y, 0f);
		topRightGO.transform.localPosition = new Vector3(activeWidth - 120f, topRightGO.transform.localPosition.y, 0f);
		Vector4 clipRange = panel.clipRange;
		clipRange.y = (float)(-num2) / 2f;
		clipRange.w = num2;
		panel.clipRange = clipRange;
		draggablePanel.transform.localPosition = new Vector3(draggablePanel.transform.localPosition.x, 0f, draggablePanel.transform.localPosition.z);
		withdrawTable.onReposition = delegate
		{
			leftTopTable.repositionNow = true;
		};
		leftTopTable.onReposition = delegate
		{
			float num3 = lastSpacerGO.transform.localPosition.x - 2f * leftTopTable.padding.x;
			leftTopTable.transform.localPosition = leftTopTable.transform.localPosition.ReplaceX(0f - num3);
		};
	}

	private void DepositClick(GameObject go)
	{
		GuiElementSingle<CardpoolDialog>.instance.ShowDeposit(GameLoginManager.currentPlayer.GetDepositedCards());
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!GuiScreenSingle<SquadScreen>.instance.isShowed || !mIsActive)
		{
			return;
		}
		switch (action)
		{
		case DatabaseAction.GetAllSquadMembers:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName);
			if (list == null)
			{
				list = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName, ommitTime: true);
			}
			if (list != null)
			{
				DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
				int num = list.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id);
				if (num > -1)
				{
					list[num].playerVisuals = generatedCurrentPlayer.playerVisuals;
					list[num].country = generatedCurrentPlayer.country;
					list[num].level = generatedCurrentPlayer.level;
					list[num].squadRank = generatedCurrentPlayer.squadRank;
					list[num].armyPower = generatedCurrentPlayer.armyPower;
					list[num].leagueTier = generatedCurrentPlayer.leagueTier;
					list[num].beginnersLeague = generatedCurrentPlayer.beginnersLeague;
					list[num].remainingMatches = generatedCurrentPlayer.remainingMatches;
					list[num].skill = generatedCurrentPlayer.skill;
					list[num].depositedCardsDic = generatedCurrentPlayer.depositedCardsDic;
					list[num].reputation = generatedCurrentPlayer.reputation;
				}
				else
				{
					list.Add(generatedCurrentPlayer);
				}
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					if (string.IsNullOrEmpty(list[num2].name))
					{
						list.RemoveAt(num2);
					}
				}
				list.Sort(SortFunctionPlayers);
			}
			else
			{
				list = new List<DatabasePlayer>();
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			DisplaySquadMembers(list);
			break;
		}
		case DatabaseAction.GetSquadDetails:
			if (waitingSprite.gameObject.activeSelf)
			{
				InitGUIValues();
			}
			break;
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && mIsActive)
		{
			if (action == DatabaseAction.DepositCards || action == DatabaseAction.WithdrawCard)
			{
				Debug.LogError("Cardpool: Deposit or Withdraw Failed");
				InitGUIValues();
			}
		}
	}

	public void OnWithdrawTimeChanged()
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && mIsActive)
		{
			InitializeWithdraw();
		}
	}

	private int SortFunctionPlayers(DatabasePlayer a, DatabasePlayer b)
	{
		if (a.reputation != b.reputation)
		{
			return b.reputation.CompareTo(a.reputation);
		}
		if (a.level != b.level)
		{
			return b.level.CompareTo(a.level);
		}
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	public void Animate(bool showTab, bool instant)
	{
		mIsActive = showTab;
		if (mIsActive && base.gameObject.activeSelf)
		{
			InitGUIValues();
		}
		if (mIsActive && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(panelMain.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
			TweenAlpha.Begin(counterPanel.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
			TweenAlpha.Begin(panel.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
			{
				if (!mIsActive)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!mIsActive)
		{
			InstantHideTab();
		}
	}

	public void InitGUIValues()
	{
		cardpoolGrid.MakeEmpty();
		waitingSprite.gameObject.SetActive(value: true);
		GuiScreenSingle<SquadScreen>.instance.CardpoolNotifications();
		CardManager.instance.InitializeBuddyWarcard();
		Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(GameLoginManager.currentPlayer.squadName);
		if (!PlayerAnalytics.instance.data.cardpoolShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new CardpoolTutorialMessage());
		}
	}

	public void DoAfterHide()
	{
		cardpoolGrid.MakeEmpty();
		withdrawAvailable.StopCountingTo();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = panel.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = panelMain.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	public void DisplaySquadMembers(List<DatabasePlayer> squadMembers)
	{
		if (squadMembers == null)
		{
			return;
		}
		bool flag = !waitingSprite.gameObject.activeSelf;
		List<string> list = new List<string>();
		foreach (DatabasePlayer squadMember in squadMembers)
		{
			Card[] depositedCards = squadMember.GetDepositedCards();
			foreach (Card card in depositedCards)
			{
				if (card.isBuddyCard)
				{
					list.Add(card.id);
				}
			}
		}
		list.AddRange(GuiElementSingle<ChatGuiElement>.instance.messageContent.messageBuddies);
		CardManager.instance.ResetSquadCards(list);
		if (flag)
		{
			UpdateSquadMembers(squadMembers);
			return;
		}
		mMemberRecords = squadMembers;
		FillReputationPoints();
		InitializeWithdraw();
		waitingSprite.gameObject.SetActive(value: false);
		cardpoolGrid.MakeEmpty();
		cardpoolGrid.init(mMemberRecords.Count, MemberInstantiate, MemberFree, draggablePanel);
		draggablePanel.AlignToPos(instant: false);
	}

	private void UpdateSquadMembers(List<DatabasePlayer> squadMembers)
	{
		if (squadMembers.Count != mMemberRecords.Count)
		{
			cardpoolGrid.MakeEmpty();
			waitingSprite.gameObject.SetActive(value: true);
			DisplaySquadMembers(squadMembers);
			return;
		}
		mMemberRecords = squadMembers;
		FillReputationPoints();
		for (int i = 0; i < cardpoolGrid.containItems; i++)
		{
			Transform itemOnIndex = cardpoolGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null)
				{
					component.FreeTextures();
					component.Initialize(mMemberRecords[i], i + 1, CardManager.instance.isWithdrawAvailable, CanBeNotified(mMemberRecords[i].id));
				}
			}
		}
	}

	private void FillReputationPoints()
	{
		int num = mMemberRecords.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id);
		int num2 = ((num >= 0) ? mMemberRecords[num].reputation : 0);
		reputationPointsLabel.text = MiscTools.FormatBigNumber(num2);
	}

	private Transform MemberInstantiate(int index)
	{
		if (index >= 0 && index < mMemberRecords.Count)
		{
			CardpoolRecord cardpoolRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(cardpoolRecordPrefab, cardpoolGrid.gameObject, index.ToString("D2")) as CardpoolRecord;
			if (cardpoolRecord != null)
			{
				cardpoolRecord.Initialize(mMemberRecords[index], index + 1, CardManager.instance.isWithdrawAvailable, CanBeNotified(mMemberRecords[index].id));
				return cardpoolRecord.transform;
			}
		}
		return null;
	}

	private void MemberFree(Transform obj)
	{
		if (obj != null)
		{
			CardpoolRecord component = obj.GetComponent<CardpoolRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void InitializeWithdraw()
	{
		if (CardManager.instance.isWithdrawAvailable)
		{
			WithdrawAvailable();
		}
		else
		{
			WithdrawWaiting(CardManager.instance.nextWithdraw);
		}
	}

	private void WithdrawAvailable()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		withdrawAvailable.StopCountingTo();
		WinStreakCounter winStreakCounter = withdrawAvailable;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(InitializeWithdraw));
		withdrawAvailable.counterLabel.text = Colours.stringPink + Localization.Localize("ID_ISAVAILABLENOW");
		firstTextWithdraw.gameObject.SetActive(value: false);
		withdrawTable.repositionNow = true;
		for (int i = 0; i < mMemberRecords.Count; i++)
		{
			Transform itemOnIndex = cardpoolGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null)
				{
					component.SetWithdraw(CardManager.instance.isWithdrawAvailable);
				}
			}
		}
	}

	private void WithdrawWaiting(int nextTime)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		WinStreakCounter winStreakCounter = withdrawAvailable;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(InitializeWithdraw));
		WinStreakCounter winStreakCounter2 = withdrawAvailable;
		winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(InitializeWithdraw));
		withdrawAvailable.StartCountingTo(nextTime);
		firstTextWithdraw.gameObject.SetActive(value: true);
		withdrawTable.repositionNow = true;
		for (int i = 0; i < mMemberRecords.Count; i++)
		{
			Transform itemOnIndex = cardpoolGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null)
				{
					component.SetWithdraw(CardManager.instance.isWithdrawAvailable);
				}
			}
		}
	}

	public void WithdrewCard(DatabasePlayer player, Card card, int newReputationPoints)
	{
		for (int i = 0; i < mMemberRecords.Count; i++)
		{
			Transform itemOnIndex = cardpoolGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null && mMemberRecords[i].id == player.id)
				{
					component.RemoveCardFromPool(card, newReputationPoints);
				}
			}
		}
		InitializeWithdraw();
	}

	public void DepositedWarcards(List<Card> depositedWarcards, List<Card> newlyDeposited)
	{
		Card[] array = new Card[depositedWarcards.Count];
		for (int i = 0; i < depositedWarcards.Count; i++)
		{
			array[i] = depositedWarcards[i];
		}
		for (int j = 0; j < mMemberRecords.Count; j++)
		{
			Transform itemOnIndex = cardpoolGrid.GetItemOnIndex(j);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null && mMemberRecords[j].id == GameLoginManager.currentPlayer.id)
				{
					component.InitializeWarcards(array);
					component.AnimateWarcards(newlyDeposited);
				}
			}
		}
	}

	private bool CanBeNotified(string id)
	{
		if (mNotificationRestriction.ContainsKey(id))
		{
			return Singleton<BeanstalkServerManager>.instance.currentTimestamp > mNotificationRestriction[id];
		}
		return true;
	}

	public void Notified(string id)
	{
		mNotificationRestriction[id] = Singleton<BeanstalkServerManager>.instance.currentTimestamp + 86400;
	}

	public void UpdateScreenCache(string playerId, Dictionary<string, string> actualDepositedWarcards, int reputationPoints = -1)
	{
		for (int i = 0; i < mMemberRecords.Count; i++)
		{
			if (mMemberRecords[i].id == playerId)
			{
				mMemberRecords[i].depositedCardsDic = actualDepositedWarcards;
				if (reputationPoints >= 0)
				{
					mMemberRecords[i].reputation = reputationPoints;
				}
			}
		}
	}
}
