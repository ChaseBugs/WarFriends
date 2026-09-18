using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class LeagueContent : Core_BaseScript
{
	public enum Type
	{
		Header,
		Player,
		HeaderReward,
		HeaderNoReward
	}

	public class LeagueRecord
	{
		public LeagueType colorType;

		public Type type;

		public League hintLeague;

		public League showLeague;

		public int goldReward;

		public int requiredMedals;

		public int myPosition;

		public DatabasePlayer player;

		public int position;

		public LeagueRecord(LeagueType colorT, Type t, int medals, League showL, League hintL, int pos, int myPos)
		{
			colorType = colorT;
			type = t;
			requiredMedals = medals;
			showLeague = showL;
			hintLeague = hintL;
			position = pos;
			myPosition = myPos;
		}

		public LeagueRecord(LeagueType colorT, Type t, int reward)
		{
			colorType = colorT;
			type = t;
			goldReward = reward;
		}

		public LeagueRecord(LeagueType colorT, Type t, DatabasePlayer p, int pos)
		{
			colorType = colorT;
			type = t;
			player = p;
			position = pos;
		}
	}

	[Header("Not in League")]
	public GameObject notInLeaguePart;

	public UITexture leagueToAssign;

	public UILabel hintToAssign;

	public UIButton toMultiplayer;

	[Header("In League")]
	public GameObject inLeaguePart;

	public PlayerLeagueLeftContent leftContent;

	[Header("-Right Header")]
	public UIPanel tableLeftLeaguePanel;

	public UISprite tableLeftLeagueIcon;

	public UILabel tableTopCenterLabel;

	public BoxCollider leagueHintCollider;

	public UISprite leagueHintSprite;

	public UILabel leagueEndTimeLabel;

	public UIButtonSetter progressBeginners;

	public UISprite beginnersProgressBar;

	public UITable beginnersProgressTable;

	public UILabel beginnersProgressLabel;

	[Header("-Right List")]
	public GameObject tableTopCenter;

	public PlayerLeagueRecord playerLeagueRecordPrefab;

	public UIPanel positionsPanel;

	public UIDraggablePanel positionsScrollview;

	public UIPooledClassicTable leaguePositionsTable;

	[Header("--Waiting")]
	public UISprite waitingForDatabase;

	[Header("In League - Processing")]
	public GameObject inLeagueProcessingPart;

	private List<LeagueRecord> mLeagueRecordData = new List<LeagueRecord>();

	private int mLeagueEnd;

	private float mTimer;

	private League mPlayerLeague;

	private League mNextLeague;

	private League mDoubleNextLeague;

	private League mTrippleNextLeague;

	private League mPreviousLeague;

	private League mAssignToLeague;

	private int mPositionPromote;

	private int mPositionDemotes;

	private bool mLowPlayers;

	private float mWidth = 1104f;

	private float mHeight;

	public Color BackgroundColor(int position)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Colours.grayLeagueBg;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		LeagueType type = Singleton<GameVariables>.instance.LeaguePositionType(mLowPlayers, leagueTier, position, mPositionPromote, mPositionDemotes);
		return Singleton<GameVariables>.instance.LeaguePositionColorLeagueRecordBg(type);
	}

	public Color PositionColor(int position)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Color.white;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		LeagueType type = Singleton<GameVariables>.instance.LeaguePositionType(mLowPlayers, leagueTier, position, mPositionPromote, mPositionDemotes);
		return Singleton<GameVariables>.instance.LeaguePositionColorLeagueRecord(type);
	}

	public int GetTopPromoted()
	{
		return mPositionPromote;
	}

	public void Animate(bool showTab, bool instant)
	{
		if (showTab && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(positionsPanel.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(tableLeftLeaguePanel.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(leftContent.leagueIconsPanel.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(base.gameObject, (!instant) ? (GuiScreenSingle<LeaguesScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
			{
				if (!showTab)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!showTab)
		{
			InstantHideTab();
		}
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		LeagueArcManager.instance.SorterPlayersLeague += OnSorterPlayersLeague;
		FakePlayersManager.instance.GeneratedPlayers += OnGeneratedFakePlayersUpdate;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(toMultiplayer.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ToMultiplayerClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(leagueHintCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LeagueHintClick));
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.PlayerLeagueProcessingChanged = (Action)Delegate.Combine(instance.PlayerLeagueProcessingChanged, new Action(OnPlayerLeagueProcessingChanged));
		UITable uITable = beginnersProgressTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, (UITable.OnReposition)delegate
		{
			float val = 0f - beginnersProgressTable.padding.x - (beginnersProgressLabel.transform.parent.transform.localPosition.x - beginnersProgressTable.padding.x) / 2f;
			beginnersProgressTable.transform.localPosition = beginnersProgressTable.transform.localPosition.ReplaceX(val);
		});
		leftContent.InitControls();
		SetSizes();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			if (action == DatabaseAction.RemoveFromLeague)
			{
				InitGUIValues();
			}
		}
	}

	private void OnSorterPlayersLeague(int myPosition, List<DatabasePlayer> databasePlayers)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			waitingForDatabase.gameObject.SetActive(value: false);
			DisplayPlayers(databasePlayers);
		}
	}

	private void OnGeneratedFakePlayersUpdate()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			DisplayFakePlayers();
		}
	}

	private void ToMultiplayerClick(GameObject go)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void LeagueHintClick(GameObject go)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LeagueHintDialog>.instance, 0f);
		SoundsManager.Instance.PlayButtonClickedSound();
		Vector3 vector = new Vector3(34f, 40f, 1f);
		TweenScale tweenScale = TweenScale.Begin(leagueHintSprite.gameObject, 0.2f, vector, vector.MultiplyXY(1.1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void OnPlayerLeagueProcessingChanged()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			InitGUIValues();
		}
	}

	private void SetSizes()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = UIRoot.list[0].activeHeight;
		float num2 = Mathf.Abs(base.transform.parent.localPosition.y);
		float num3 = num2 + 62f;
		float num4 = 636f;
		float num5 = activeWidth - (120f + num4);
		float num6 = num - num3;
		mWidth = num5;
		mHeight = num6;
		tableTopCenter.transform.localPosition = tableTopCenter.transform.localPosition.ReplaceX(num4 + num5 / 2f);
	}

	private void SetListHeight(bool isBeginnerLeague)
	{
		float num = mWidth;
		float num2 = mHeight - ((!isBeginnerLeague) ? 0f : 168f);
		float y = (0f - num2) / 2f - ((!isBeginnerLeague) ? 0f : 168f);
		positionsPanel.clipRange = new Vector4(0f, y, num + 30f, num2);
		positionsScrollview.transform.localPosition = new Vector3(0f, 0f, positionsScrollview.transform.localPosition.z);
	}

	public void InitGUIValues()
	{
		SetCorrectLook();
		if (!PlayerAnalytics.instance.data.leagueLeaderboardsShown)
		{
			Singleton<BeanstalkServerManager>.instance.LeagueLeaderboardsShown();
			Singleton<EventTrackingManager>.instance.RegisterLeagueLeaderboardShown(GameLoginManager.currentPlayer.leagueTier);
		}
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isPlayerLeagueProcessing = Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing;
		mLeagueEnd = LeagueArcManager.instance.GetLeagueTimer();
		leagueEndTimeLabel.text = string.Empty;
		if (isInBeginnersLeague)
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int num = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(beginnersLeague);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int beginnersNumber = beginnersLeague + 1;
			leftContent.InitGUIValues();
			tableLeftLeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			tableTopCenterLabel.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
			progressBeginners.gameObject.SetActive(value: true);
			progressBeginners.SetWidth(mWidth);
			beginnersProgressBar.fillAmount = (float)medalsBalance / (float)num;
			beginnersProgressTable.repositionNow = true;
			beginnersProgressLabel.text = Localization.LocalizeFormat("ID_GETTOADVANCETOLEAGUE2", num - medalsBalance, Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersNumber));
			leaguePositionsTable.MakeEmpty();
			mLeagueRecordData.Clear();
			SetListHeight(isBeginnerLeague: true);
			waitingForDatabase.gameObject.SetActive(value: true);
			FakePlayersManager.instance.GeneratePlayersForLeague();
		}
		else
		{
			if (isPlayerLeagueProcessing)
			{
				return;
			}
			if (isInLeague)
			{
				mPlayerLeague = GameLoginManager.currentPlayer.leagueTier;
				mNextLeague = (League)Mathf.Clamp((int)(mPlayerLeague + 1), 1, 16);
				mDoubleNextLeague = (League)Mathf.Clamp((int)(mPlayerLeague + 2), 1, 16);
				mTrippleNextLeague = (League)Mathf.Clamp((int)(mPlayerLeague + 3), 1, 16);
				mPreviousLeague = (League)Mathf.Clamp((int)(mPlayerLeague - 1), 1, 16);
				mPositionPromote = 10;
				mPositionDemotes = 90;
				mLowPlayers = false;
				leftContent.InitGUIValues();
				tableLeftLeagueIcon.spriteName = GameVariables.leagueNames[mPlayerLeague].Value2;
				tableTopCenterLabel.text = GameVariables.leagueNames[mPlayerLeague].Value1;
				progressBeginners.gameObject.SetActive(value: false);
				leaguePositionsTable.MakeEmpty();
				mLeagueRecordData.Clear();
				SetListHeight(isBeginnerLeague: false);
				waitingForDatabase.gameObject.SetActive(value: true);
				Singleton<BeanstalkServerManager>.instance.GetPlayersFromLeague(GameLoginManager.currentPlayer.leagueId);
			}
			else
			{
				mAssignToLeague = GameLoginManager.currentPlayer.leagueTier;
				int remainingMatches = GameLoginManager.currentPlayer.remainingMatches;
				hintToAssign.text = ((remainingMatches != 1) ? Localization.LocalizeFormat("ID_NOTINLEAGUEMOREMATCHESTEXT", remainingMatches, GameVariables.leagueNames[mAssignToLeague].Value1) : Localization.LocalizeFormat("ID_NOTINLEAGUETEXT", GameVariables.leagueNames[mAssignToLeague].Value1));
				leagueToAssign.alpha = 0f;
				if (base.gameObject.activeSelf)
				{
					ShowAssignToLeagueIcon();
				}
			}
		}
	}

	public void DoAfterHide()
	{
		leaguePositionsTable.MakeEmpty();
		mLeagueRecordData.Clear();
		leftContent.DoAfterHide();
		leagueToAssign.mainTexture = null;
	}

	public void InstantHideTab()
	{
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = positionsScrollview.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	public void ShowAssignToLeagueIcon()
	{
		leagueToAssign.alpha = ((mAssignToLeague == League.NoLeague) ? 0f : 0.7f);
		if (mAssignToLeague != League.NoLeague)
		{
			leagueToAssign.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[mAssignToLeague].Value2);
		}
	}

	private void SetCorrectLook()
	{
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool isPlayerLeagueProcessing = Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing;
		inLeagueProcessingPart.SetActive(!isInBeginnersLeague && isPlayerLeagueProcessing);
		inLeaguePart.SetActive(isInBeginnersLeague || (isInLeague && !isPlayerLeagueProcessing));
		notInLeaguePart.SetActive(!isInBeginnersLeague && !isInLeague && !isPlayerLeagueProcessing);
	}

	private void DisplayFakePlayers()
	{
		waitingForDatabase.gameObject.SetActive(value: false);
		List<DatabasePlayer> list = FakePlayersManager.instance.ListOfPlayers();
		for (int i = 0; i < list.Count; i++)
		{
			mLeagueRecordData.Add(new LeagueRecord(LeagueType.Stay, Type.Player, list[i], i + 1));
		}
		leaguePositionsTable.MakeEmpty();
		leaguePositionsTable.Initialize(mLeagueRecordData.Count, PlayerLeagueInstantiate, PlayerLeagueFree, GetRecordHeight, positionsScrollview);
		AlignTable();
	}

	private void DisplayPlayers(List<DatabasePlayer> databasePlayers)
	{
		if (base.gameObject.activeSelf && databasePlayers != null)
		{
			if (databasePlayers.Count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE)
			{
				DisplayPlayersInLeague(databasePlayers);
			}
			else
			{
				DisplayePlayersNotEnought(databasePlayers);
			}
		}
	}

	private void DisplayPlayersInLeague(List<DatabasePlayer> databasePlayers)
	{
		int count = databasePlayers.Count;
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(mPlayerLeague);
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(mPlayerLeague);
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = databasePlayers.FindIndex((DatabasePlayer p) => p.id == GameLoginManager.currentPlayer.id) + 1;
		if (mLeagueRecordData.Count > 0)
		{
			int num4 = count + 1;
			if (num > 0f)
			{
				num4 += ((leagueTier >= League.Elite3) ? 1 : 3);
			}
			if (num2 > 0f)
			{
				num4++;
			}
			if (num4 == mLeagueRecordData.Count)
			{
				UpdatePlayers(databasePlayers);
				UpdateHeaders(databasePlayers);
				UpdateShownRecords();
				leftContent.SetPositiveNumber(PositivePromotion(num3, leagueTier));
				leftContent.SetPromotedPart(ShowPositive(count, num3, leagueTier), saveType: true);
				return;
			}
		}
		mLowPlayers = false;
		mPositionPromote = Singleton<GameVariables>.instance.LeaguePositionPromote(count, mPlayerLeague);
		mPositionDemotes = Singleton<GameVariables>.instance.LeaguePositionDemote(count, mPlayerLeague);
		bool flag = leagueTier < League.Elite3;
		int num5 = (flag ? 3 : 0);
		int num6 = (flag ? 1 : (-1));
		int num7 = ((!flag) ? (-1) : 0);
		leftContent.SetPositiveNumber(PositivePromotion(num3, leagueTier));
		leftContent.SetPromotedPart(ShowPositive(count, num3, leagueTier), saveType: true);
		mLeagueRecordData.Clear();
		for (int num8 = 0; num8 < count; num8++)
		{
			int num9 = num8 + 1;
			LeagueType colorT = Singleton<GameVariables>.instance.LeaguePositionType(mLowPlayers, leagueTier, num9, mPositionPromote, mPositionDemotes);
			if (num8 == num7)
			{
				int medals = databasePlayers[num8].medalsBalance - medalsBalance;
				mLeagueRecordData.Add(new LeagueRecord(colorT, Type.Header, medals, mTrippleNextLeague, League.NoLeague, num9, num3));
			}
			if (num8 == num6)
			{
				int index = ((num9 > num3) ? num8 : (num8 - 1));
				int medals2 = databasePlayers[index].medalsBalance - medalsBalance;
				mLeagueRecordData.Add(new LeagueRecord(colorT, Type.Header, medals2, mDoubleNextLeague, mTrippleNextLeague, num9, num3));
			}
			if (num8 == num5)
			{
				int index2 = ((!flag || num9 > num3) ? num8 : (num8 - 1));
				int medals3 = databasePlayers[index2].medalsBalance - medalsBalance;
				League hintL = (flag ? mDoubleNextLeague : League.NoLeague);
				League showL = ((!(num > 0f)) ? mPlayerLeague : mNextLeague);
				mLeagueRecordData.Add(new LeagueRecord(colorT, Type.Header, medals3, showL, hintL, num9, num3));
			}
			if (num8 == mPositionPromote && mPositionPromote != mPositionDemotes && num > 0f)
			{
				int index3 = ((num9 > num3) ? num8 : (num8 - 1));
				int medals4 = databasePlayers[index3].medalsBalance - medalsBalance;
				mLeagueRecordData.Add(new LeagueRecord(colorT, Type.Header, medals4, mPlayerLeague, mNextLeague, num9, num3));
			}
			if (num8 == mPositionDemotes - 1 && num2 > 0f)
			{
				int index4 = ((num9 > num3) ? num8 : (num8 - 1));
				int medals5 = databasePlayers[index4].medalsBalance - medalsBalance;
				mLeagueRecordData.Add(new LeagueRecord(colorT, Type.Header, medals5, mPreviousLeague, mPreviousLeague, num9, num3));
			}
			mLeagueRecordData.Add(new LeagueRecord(colorT, Type.Player, databasePlayers[num8], num9));
		}
		leaguePositionsTable.MakeEmpty();
		leaguePositionsTable.Initialize(mLeagueRecordData.Count, PlayerLeagueInstantiate, PlayerLeagueFree, GetRecordHeight, positionsScrollview);
		AlignTable();
	}

	private void DisplayePlayersNotEnought(List<DatabasePlayer> databasePlayers)
	{
		int count = databasePlayers.Count;
		if (mLeagueRecordData.Count > 0)
		{
			int num = ((count <= 1) ? 1 : 2) + count;
			if (num == mLeagueRecordData.Count)
			{
				UpdatePlayers(databasePlayers);
				UpdateShownRecords();
				leftContent.SetPromotedPart(PlayerLeagueLeftContent.InfoType.None, saveType: true);
				return;
			}
		}
		mLowPlayers = true;
		mPositionPromote = 10;
		mPositionDemotes = 90;
		int num2 = Mathf.CeilToInt((float)count * 0.1f);
		leftContent.SetPromotedPart(PlayerLeagueLeftContent.InfoType.None, saveType: true);
		mLeagueRecordData.Clear();
		mLeagueRecordData.Add(new LeagueRecord(LeagueType.Stay, Type.HeaderReward, Singleton<GameVariables>.instance.GoldRewardForTopInNotEnoughtPlayersLeague(mPlayerLeague)));
		for (int i = 0; i < count; i++)
		{
			if (i == num2)
			{
				mLeagueRecordData.Add(new LeagueRecord(LeagueType.Stay, Type.HeaderNoReward, 0));
			}
			mLeagueRecordData.Add(new LeagueRecord(LeagueType.Stay, Type.Player, databasePlayers[i], i + 1));
		}
		leaguePositionsTable.MakeEmpty();
		leaguePositionsTable.Initialize(mLeagueRecordData.Count, PlayerLeagueInstantiate, PlayerLeagueFree, GetRecordHeight, positionsScrollview);
		AlignTable();
	}

	public void AlignTable()
	{
		if (mLeagueRecordData.Count == 0)
		{
			positionsScrollview.AlignToPos(instant: true);
			return;
		}
		int num = mLeagueRecordData.FindIndex((LeagueRecord data1) => data1.type == Type.Player && data1.player.id == GameLoginManager.currentPlayer.id);
		if (num < 0)
		{
			num = 0;
		}
		positionsScrollview.AlignToCenter(leaguePositionsTable.transform.localPosition + leaguePositionsTable.GetPositionForIndex(num), instant: true, delegate
		{
			leaguePositionsTable.PositionChanged();
		});
	}

	private void PlayerLeagueFree(Transform obj)
	{
		if (obj != null)
		{
			PlayerLeagueRecord component = obj.GetComponent<PlayerLeagueRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private Transform PlayerLeagueInstantiate(int index)
	{
		if (index >= 0 && index < mLeagueRecordData.Count)
		{
			string text = string.Format("{0} {1}", index.ToString("D3"), mLeagueRecordData[index].type);
			PlayerLeagueRecord playerLeagueRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(playerLeagueRecordPrefab, leaguePositionsTable.gameObject, text) as PlayerLeagueRecord;
			if (playerLeagueRecord != null)
			{
				playerLeagueRecord.InitializeRecord(mLeagueRecordData[index], mWidth);
				return playerLeagueRecord.transform;
			}
		}
		return null;
	}

	private float GetRecordHeight(int index)
	{
		if (index >= 0 && index < mLeagueRecordData.Count)
		{
			return (mLeagueRecordData[index].type != Type.Player) ? 94f : 132f;
		}
		return 0f;
	}

	private void UpdatePlayers(List<DatabasePlayer> databasePlayers)
	{
		int num = 0;
		for (int i = 0; i < mLeagueRecordData.Count; i++)
		{
			if (mLeagueRecordData[i].type == Type.Player)
			{
				if (num >= databasePlayers.Count)
				{
					Debug.LogError("Something went wrong in updating players in league");
					break;
				}
				mLeagueRecordData[i].player = databasePlayers[num];
				num++;
			}
		}
	}

	private void UpdateHeaders(List<DatabasePlayer> databasePlayers)
	{
		int count = databasePlayers.Count;
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(mPlayerLeague);
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(mPlayerLeague);
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = databasePlayers.FindIndex((DatabasePlayer p) => p.id == GameLoginManager.currentPlayer.id) + 1;
		bool flag = leagueTier < League.Elite3;
		int num4 = (flag ? 3 : 0);
		int num5 = (flag ? 1 : (-1));
		int num6 = ((!flag) ? (-1) : 0);
		int num7 = 0;
		for (int num8 = 0; num8 < count; num8++)
		{
			int index = num8 + num7;
			int num9 = num8 + 1;
			LeagueType colorT = Singleton<GameVariables>.instance.LeaguePositionType(mLowPlayers, leagueTier, num9, mPositionPromote, mPositionDemotes);
			if (num8 == num6)
			{
				int medals = databasePlayers[num8].medalsBalance - medalsBalance;
				mLeagueRecordData[index] = new LeagueRecord(colorT, Type.Header, medals, mTrippleNextLeague, League.NoLeague, num9, num3);
				num7++;
			}
			if (num8 == num5)
			{
				int index2 = ((num9 > num3) ? num8 : (num8 - 1));
				int medals2 = databasePlayers[index2].medalsBalance - medalsBalance;
				mLeagueRecordData[index] = new LeagueRecord(colorT, Type.Header, medals2, mDoubleNextLeague, mTrippleNextLeague, num9, num3);
				num7++;
			}
			if (num8 == num4)
			{
				int index3 = ((!flag || num9 > num3) ? num8 : (num8 - 1));
				int medals3 = databasePlayers[index3].medalsBalance - medalsBalance;
				League hintL = (flag ? mDoubleNextLeague : League.NoLeague);
				League showL = ((!(num > 0f)) ? mPlayerLeague : mNextLeague);
				mLeagueRecordData[index] = new LeagueRecord(colorT, Type.Header, medals3, showL, hintL, num9, num3);
				num7++;
			}
			if (num8 == mPositionPromote && mPositionPromote != mPositionDemotes && num > 0f)
			{
				int index4 = ((num9 > num3) ? num8 : (num8 - 1));
				int medals4 = databasePlayers[index4].medalsBalance - medalsBalance;
				mLeagueRecordData[index] = new LeagueRecord(colorT, Type.Header, medals4, mPlayerLeague, mNextLeague, num9, num3);
				num7++;
			}
			if (num8 == mPositionDemotes - 1 && num2 > 0f)
			{
				int index5 = ((num9 > num3) ? num8 : (num8 - 1));
				int medals5 = databasePlayers[index5].medalsBalance - medalsBalance;
				mLeagueRecordData[index] = new LeagueRecord(colorT, Type.Header, medals5, mPreviousLeague, mPreviousLeague, num9, num3);
				num7++;
			}
		}
	}

	private void UpdateShownRecords()
	{
		for (int i = 0; i < leaguePositionsTable.containItems; i++)
		{
			Transform itemOnIndex = leaguePositionsTable.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				PlayerLeagueRecord component = itemOnIndex.GetComponent<PlayerLeagueRecord>();
				if (component != null)
				{
					component.FreeTexture();
					component.InitializeRecord(mLeagueRecordData[i], mWidth);
				}
			}
		}
	}

	private PlayerLeagueLeftContent.InfoType ShowPositive(int players, int myPosition, League currentLeague)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(currentLeague);
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(currentLeague);
		bool flag = num > 0f;
		bool flag2 = num2 > 0f;
		int num3 = Singleton<GameVariables>.instance.LeaguePositionPromote(players, currentLeague);
		int num4 = Singleton<GameVariables>.instance.LeaguePositionDemote(players, currentLeague);
		if (!flag2)
		{
			return (myPosition > num3) ? PlayerLeagueLeftContent.InfoType.None : PlayerLeagueLeftContent.InfoType.Positive;
		}
		if (!flag)
		{
			return (myPosition >= num4) ? PlayerLeagueLeftContent.InfoType.Negative : PlayerLeagueLeftContent.InfoType.None;
		}
		int num5 = num3 + (int)(0.9f * (float)(num4 - num3));
		return (myPosition >= num5) ? PlayerLeagueLeftContent.InfoType.Negative : PlayerLeagueLeftContent.InfoType.Positive;
	}

	private int PositivePromotion(int myPosition, League currentLeague)
	{
		if (currentLeague < League.Elite3)
		{
			if (myPosition == 1)
			{
				return 3;
			}
			if (myPosition < 4)
			{
				return 2;
			}
		}
		return 1;
	}

	private void Update()
	{
		if (!inLeaguePart.activeSelf || mLeagueEnd <= 0)
		{
			return;
		}
		mTimer += Time.deltaTime;
		if (mTimer > 0.333f)
		{
			mTimer -= 0.333f;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = mLeagueEnd - currentTimestamp;
			if ((float)num > 0f)
			{
				leagueEndTimeLabel.text = Localization.LocalizeFormat("ID_ENDSINTIME", Colours.stringWhite, MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty));
				MiscTools.SetUILabelRescale(leagueEndTimeLabel, 30f, 20f, 400);
			}
			else
			{
				leagueEndTimeLabel.text = string.Empty;
			}
		}
	}
}
