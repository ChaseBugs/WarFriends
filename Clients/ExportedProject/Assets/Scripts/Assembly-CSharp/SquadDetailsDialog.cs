using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SquadDetailsDialog : GuiElementSingle<SquadDetailsDialog>, IGuiDialog
{
	[Header("Dialog Core")]
	public GameObject dialogCenter;

	public UISprite background;

	[Header("Top Button")]
	public UIButton buttonClose;

	[Header("-Header")]
	public UISprite squadRankIcon;

	public UILabel squadRank;

	public UITable headerTable;

	public UITexture squadIcon;

	public GameObject rightItem;

	public UILabel squadNameLabel;

	[Header("-Middle")]
	public GameObject middleCorePart;

	public GameObject infoPart;

	public GameObject tablePart;

	[Header("--Message Part")]
	public GameObject messagePart;

	public UILabel squadMessageLabel;

	[Header("--Info Win Lose")]
	public UILabel winLoseRatio;

	public UILabel wonLostBattles;

	[Header("--Info Squad Wars")]
	public UITable squadPointsTable;

	public UILabel squadPointsLabel;

	public UILabel squadWarsSquadPosition;

	public GameObject divisionPart;

	public UILabel divisionName;

	public UISprite[] divisionArrows;

	[Header("--Info Squad Medals")]
	public UILabel squadMedalsLabel;

	public UILabel bestSquadMedalsLabel;

	[Header("--Info Global Position")]
	public UILabel globalPositionLabel;

	[Header("--Center Table")]
	public UILabel tableHeader;

	public SquadDetailsMemberGridElement memberRecordPrefab;

	public UIPooledGrid membersGrid;

	public UIDraggablePanel draggablePanel;

	[Header("--Waiting for server")]
	public UISprite waitingSprite;

	[Header("-Bottom Part")]
	public GameObject bottomPart;

	[Header("--Private Squad")]
	public GameObject privateSquad;

	public UILabel privateSquadLabel;

	[Header("--Join Button")]
	public UIButton buttonJoinSquad;

	public BoxCollider buttonJoinSquadCollider;

	public UISprite buttonJoinSquadBackground;

	public UILabel buttonJoinSquadLabel;

	private string mSquadName;

	private DatabaseSquad mSquad;

	private List<SquadMemberContent.ManagementRecord> mManagementRecords = new List<SquadMemberContent.ManagementRecord>();

	private int mSquadMedals;

	private DatabasePlayerInfo mPlayer;

	private bool mTurnOffDragBackground;

	private bool mIsBot;

	private float mSizeOfSquadIcon = 114f;

	public void ShowDialog(string squadName)
	{
		Debug.Log("Showing squad details dialog with SQUADNAME = " + squadName);
		mSquadName = squadName;
		mPlayer = null;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadDetailsDialog>.instance, 0f);
	}

	public void ShowDialog(string squadName, DatabasePlayerInfo playerInfo, bool turnOffDragBackground, bool isBot)
	{
		Debug.Log("Showing squad details dialog with SQUADNAME = " + squadName + " on close show player dialog for " + playerInfo.name);
		bool flag = mSquadName == squadName;
		mSquadName = squadName;
		mPlayer = playerInfo;
		mTurnOffDragBackground = turnOffDragBackground;
		mIsBot = isBot;
		if (isShowed)
		{
			if (!flag)
			{
				InitGUIValues();
			}
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadDetailsDialog>.instance, 0f);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonJoinSquad.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnJoinSquad));
		UIEventListener uIEventListener2 = UIEventListener.Get(buttonClose.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.SquadWarProcessingChanged = (Action)Delegate.Combine(serverResultsCache.SquadWarProcessingChanged, (Action)delegate
		{
			if (isShowed)
			{
				SetSquadButton();
			}
		});
		headerTable.onReposition = delegate
		{
			bool flag = squadIcon.alpha == 1f;
			float num = 0f;
			num = ((!flag) ? (0f - rightItem.transform.localPosition.x + squadNameLabel.relativeSize.x * squadNameLabel.transform.localScale.x / 2f) : (0f - headerTable.padding.x - (rightItem.transform.localPosition.x - headerTable.padding.x) / 2f));
			headerTable.transform.localPosition = headerTable.transform.localPosition.ReplaceX(num);
		};
		privateSquadLabel.text = string.Format("   {0}", Localization.Localize("ID_ACCEPTEDMEMBERSONLY"));
		if (Localization.instance.currentLanguage == "fr")
		{
			privateSquadLabel.lineWidth = 300;
		}
	}

	private void OnJoinSquad(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) || LevelManager.instance.isSquadJoinLocked || mSquad == null)
		{
			return;
		}
		if (mSquad.GetPlacesLeft() <= 0)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADFULL"), Localization.Localize("ID_CONFIRM_SQUADISALREADYFULL"), 0f);
			return;
		}
		if (GameLoginManager.currentPlayer.skill < mSquad.skillRequirement)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(mSquad.name, mSquad.skillRequirement, GameLoginManager.currentPlayer.skill);
			return;
		}
		if (!mSquad.isPublic)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(mSquad.name);
			return;
		}
		string squadName = mSquad.name;
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_JOININGSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_JOININGSQUAD_TEXT", Colours.stringBlue, squadName, Colours.stringWhite), delegate(ConfirmDialog dialog, bool result)
		{
			if (result)
			{
				Singleton<BeanstalkServerManager>.instance.JoinSquad(squadName, string.Empty);
			}
		}, 0f);
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!isShowed)
		{
			return;
		}
		if (action != DatabaseAction.GetFullSquadInfo)
		{
			return;
		}
		List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(mSquadName);
		if (squadMembers != null)
		{
			int num = squadMembers.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id);
			if (num > -1)
			{
				DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
				squadMembers[num].playerVisuals = generatedCurrentPlayer.playerVisuals;
				squadMembers[num].level = generatedCurrentPlayer.level;
				squadMembers[num].armyPower = generatedCurrentPlayer.armyPower;
				squadMembers[num].skill = generatedCurrentPlayer.skill;
			}
			for (int num2 = squadMembers.Count - 1; num2 >= 0; num2--)
			{
				if (string.IsNullOrEmpty(squadMembers[num2].name))
				{
					squadMembers.RemoveAt(num2);
				}
			}
			squadMembers.Sort(SortFunctionPlayers);
		}
		ShowSquadInfo(Singleton<ServerResultsCache>.instance.GetSquad(mSquadName));
		ShowSquadMembers(squadMembers);
	}

	private int SortFunctionPlayers(DatabasePlayer a, DatabasePlayer b)
	{
		if (a.skill != b.skill)
		{
			return b.skill.CompareTo(a.skill);
		}
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	public override void InitGUIValues()
	{
		waitingSprite.gameObject.SetActive(value: true);
		InitBlank();
		Singleton<BeanstalkServerManager>.instance.GetFullSquadInfo(mSquadName);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed)
		{
			GuiElementSingle<ChatGuiElement>.instance.chatContent.draggablePanel.forceDrag = false;
			GuiElementSingle<ChatGuiElement>.instance.messageContent.draggablePanel.forceDrag = false;
			return;
		}
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<SelectFriendsDialog>.instance.friendsScrollview.forceDrag = false;
		GuiElementSingle<SelectFriendsDialog>.instance.friendsScrollview.onePanelDisabled = true;
		GuiScreenSingle<LeaguesScreen>.instance.allTime.draggablePanel.onePanelDisabled = true;
		GuiScreenSingle<LeaguesScreen>.instance.squadWars.draggableSquads.onePanelDisabled = true;
		GuiScreenSingle<LeaguesScreen>.instance.squadWars.draggableMembers.onePanelDisabled = true;
		GuiScreenSingle<LeaguesScreen>.instance.league.positionsScrollview.onePanelDisabled = true;
		GuiScreenSingle<SquadFindScreen>.instance.globalResults.draggablePanel.onePanelDisabled = true;
		GuiScreenSingle<SquadFindScreen>.instance.localResults.draggablePanel.onePanelDisabled = true;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed)
		{
			GuiElementSingle<ChatGuiElement>.instance.chatContent.draggablePanel.forceDrag = true;
			GuiElementSingle<ChatGuiElement>.instance.messageContent.draggablePanel.forceDrag = true;
		}
		else
		{
			UIDraggablePanel.panelDisabled = false;
			GuiElementSingle<SelectFriendsDialog>.instance.friendsScrollview.forceDrag = true;
			GuiElementSingle<SelectFriendsDialog>.instance.friendsScrollview.onePanelDisabled = false;
			GuiScreenSingle<LeaguesScreen>.instance.allTime.draggablePanel.onePanelDisabled = false;
			GuiScreenSingle<LeaguesScreen>.instance.squadWars.draggableSquads.onePanelDisabled = false;
			GuiScreenSingle<LeaguesScreen>.instance.squadWars.draggableMembers.onePanelDisabled = false;
			GuiScreenSingle<LeaguesScreen>.instance.league.positionsScrollview.onePanelDisabled = false;
			GuiScreenSingle<SquadFindScreen>.instance.globalResults.draggablePanel.onePanelDisabled = false;
			GuiScreenSingle<SquadFindScreen>.instance.localResults.draggablePanel.onePanelDisabled = false;
		}
		squadIcon.mainTexture = null;
		membersGrid.MakeEmpty();
		mSquad = null;
		mSquadName = null;
		if (mPlayer != null)
		{
			if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu && !GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialogFromCache(mPlayer, mTurnOffDragBackground, mIsBot);
			}
			mPlayer = null;
		}
	}

	private void SetDialogSize(bool bigSize)
	{
		dialogCenter.transform.localPosition = new Vector3(0f, (!bigSize) ? (-44f) : 0f, 0f);
		background.transform.localScale = background.transform.localScale.ReplaceY((!bigSize) ? 1052f : 1140f);
		messagePart.SetActive(bigSize);
		infoPart.transform.localPosition = new Vector3(0f, (!bigSize) ? 0f : (-88f), 0f);
		tablePart.transform.localPosition = new Vector3(0f, (!bigSize) ? (-212f) : (-300f), 0f);
		bottomPart.transform.localPosition = new Vector3(0f, (!bigSize) ? (-314f) : (-402f), 0f);
	}

	private void InitBlank()
	{
		SetDialogSize(bigSize: true);
		squadRankIcon.gameObject.SetActive(value: false);
		squadRank.text = string.Empty;
		squadIcon.alpha = 0f;
		squadNameLabel.text = mSquadName;
		headerTable.repositionNow = true;
		divisionName.text = string.Empty;
		for (int i = 0; i < divisionArrows.Length; i++)
		{
			divisionArrows[i].gameObject.SetActive(value: false);
		}
		squadMessageLabel.text = string.Empty;
		middleCorePart.SetActive(value: false);
		privateSquad.SetActive(value: false);
		buttonJoinSquad.gameObject.SetActive(value: false);
	}

	private void ShowSquadInfo(DatabaseSquad squad)
	{
		mSquad = squad;
		if (squad == null)
		{
			ShowEmptySquad();
			return;
		}
		squadRankIcon.gameObject.SetActive(value: true);
		squadRank.text = squad.rank.ToString();
		SetSquadIcon(squad.icon);
		squadNameLabel.text = squad.name;
		headerTable.repositionNow = true;
		SetSquadMessage(squad.message);
		bool isInDivision = squad.isInDivision;
		int squadWarDivision = squad.squadWarDivision;
		Debug.Log($"Squad Details - squad wars position:{squad.warsPosition}, global postion:{squad.globalPosition}");
		middleCorePart.SetActive(value: true);
		winLoseRatio.text = ((!(squad.winLoseRatio < 0f)) ? MiscTools.FormatFloatNumberRoundOne(squad.winLoseRatio) : Localization.Localize("ID_NA"));
		wonLostBattles.text = $"{squad.battlesWon} {Colours.stringGray}/{Colours.stringRedLostMatches} {squad.battlesLost}";
		MiscTools.SetUILabelRescale(wonLostBattles, 37f, 25f, 270);
		squadPointsLabel.text = MiscTools.FormatBigNumber(squad.squadPoints);
		divisionPart.SetActive(isInDivision);
		globalPositionLabel.text = ((squad.globalPosition != 0) ? MiscTools.FormatNumberToOrdinalPoint(squad.globalPosition) : "100+.");
		squadPointsTable.repositionNow = true;
		if (isInDivision)
		{
			squadWarsSquadPosition.text = ((squad.warsPosition != 0) ? MiscTools.FormatNumberToOrdinalPoint(Mathf.Clamp(squad.warsPosition, 1, 100)) : "100.");
			divisionName.text = string.Format("{0} {1}", Localization.Localize("ID_DIVISION"), 9 - squadWarDivision);
			for (int i = 0; i < divisionArrows.Length; i++)
			{
				divisionArrows[i].gameObject.SetActive(i < squadWarDivision);
			}
		}
		else
		{
			squadWarsSquadPosition.text = "-";
		}
		tableHeader.text = Localization.LocalizeFormat("ID_SQUADMEMBERSCOUNT", squad.size, squad.size + squad.GetPlacesLeft());
		privateSquad.SetActive(!squad.isPublic);
		buttonJoinSquad.gameObject.SetActive(value: true);
		SetSquadButton();
	}

	private void ShowEmptySquad()
	{
		squadRankIcon.gameObject.SetActive(value: false);
		squadRank.text = string.Empty;
		squadNameLabel.text = string.Empty;
		SetSquadIcon(string.Empty);
		headerTable.repositionNow = true;
		middleCorePart.SetActive(value: false);
		privateSquad.SetActive(value: false);
		buttonJoinSquad.gameObject.SetActive(value: true);
		SetSquadButton();
	}

	private void SetSquadIcon(string squadIconName)
	{
		bool flag = false;
		foreach (SquadEmblemsRow row in Singleton<GameVariables>.instance.squadEmblems.Rows)
		{
			if (row.ICONNAME == squadIconName)
			{
				flag = true;
			}
		}
		if (flag)
		{
			squadIcon.alpha = 1f;
			squadIcon.mainTexture = Resources.Load<Texture>("SquadIcons/" + squadIconName);
			squadIcon.MakePixelPerfect();
			float multiplier = mSizeOfSquadIcon / squadIcon.transform.localScale.x;
			squadIcon.transform.localScale = squadIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			squadIcon.alpha = 0f;
			squadIcon.mainTexture = null;
			squadIcon.transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}

	private void SetSquadMessage(string message)
	{
		bool flag = !string.IsNullOrEmpty(message);
		SetDialogSize(flag);
		if (flag)
		{
			squadMessageLabel.text = message;
		}
	}

	private void SetSquadButton()
	{
		bool flag = mSquad != null;
		bool flag2 = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		bool flag3 = LevelManager.instance.currentLevel.displayNumber >= joinSquadUnlockLevel;
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		bool flag4 = flag && mSquad.size > 0 && flag2 && flag3 && !isSquadWarsProcessing;
		bool flag5 = true;
		if (flag)
		{
			flag5 = mSquad.isPublic;
		}
		buttonJoinSquadCollider.enabled = flag4;
		buttonJoinSquadBackground.color = ((!flag4) ? Color.gray : Color.white);
		buttonJoinSquadLabel.text = Localization.Localize((!flag5) ? "ID_REQUESTJOIN" : "ID_JOINSQUAD");
		MiscTools.SetUILabelRescale(buttonJoinSquadLabel, 57f, 20f, 570);
	}

	public void ShowSquadMembers(IEnumerable<DatabasePlayer> squadMembers)
	{
		waitingSprite.gameObject.SetActive(value: false);
		membersGrid.MakeEmpty();
		mManagementRecords.Clear();
		squadMedalsLabel.text = string.Empty;
		bestSquadMedalsLabel.text = string.Empty;
		if (squadMembers == null)
		{
			return;
		}
		int num = 0;
		float num2 = 0f;
		foreach (DatabasePlayer squadMember in squadMembers)
		{
			mManagementRecords.Add(SquadMemberContent.ManagementRecord.GetRecord(squadMember));
			num2 += (float)squadMember.skill * Singleton<GameVariables>.instance.GetSquadMedalWeight(num);
			num++;
		}
		mSquad.skill = MiscTools.RoundToInt(num2);
		mSquad.bestSkill = Mathf.Max(mSquad.bestSkill, mSquad.skill);
		Singleton<ServerResultsCache>.instance.UpdateSquad(mSquad);
		squadMedalsLabel.text = MiscTools.FormatBigNumber(mSquad.skill);
		bestSquadMedalsLabel.text = MiscTools.FormatBigNumber(mSquad.bestSkill);
		membersGrid.init(mManagementRecords.Count, MemberInstantiate, MemberFree, draggablePanel);
		draggablePanel.AlignToPos(instant: true);
	}

	private Transform MemberInstantiate(int index)
	{
		if (index >= 0 && index < mManagementRecords.Count)
		{
			SquadMemberContent.ManagementRecord managementRecord = mManagementRecords[index];
			SquadDetailsMemberGridElement squadDetailsMemberGridElement = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(memberRecordPrefab, membersGrid.gameObject, string.Format("{0} Squad Member {1}", index.ToString("D2"), managementRecord.member.name)) as SquadDetailsMemberGridElement;
			if (squadDetailsMemberGridElement != null)
			{
				squadDetailsMemberGridElement.InitializeMember(managementRecord.member, index + 1);
				return squadDetailsMemberGridElement.transform;
			}
		}
		return null;
	}

	private void MemberFree(Transform obj)
	{
		if (obj != null)
		{
			SquadDetailsMemberGridElement component = obj.GetComponent<SquadDetailsMemberGridElement>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(buttonClose.gameObject);
	}
}
