using System;
using UnityEngine;

public class MemberRecord : PoolableObject
{
	[Header("Width Setter")]
	public UIButtonSetter buttonSetter;

	[Header("Member Record")]
	public GameObject memberPart;

	public UISprite highlight;

	[Header("-Info")]
	public UILabel position;

	public PlayerIcon avatar;

	public GameObject playerIconButton;

	public UISprite countryIcon;

	public UISprite rankIcon;

	public UILabel rankNumber;

	public UILabel functionLabel;

	[Header("--Name")]
	public UITable nameTable;

	public UILabel nickLabel;

	public BoxCollider playerButton;

	public GameObject crownPart;

	public UISprite crownIcon;

	public GameObject statusPart;

	public UISprite statusIcon;

	[Header("-Functions and Buttons")]
	public GameObject squadMemberPart;

	public GameObject changeLeaderShip;

	public GameObject promoteButton;

	public GameObject demoteButton;

	public GameObject promoteButtonSmall;

	public GameObject demoteButtonSmall;

	[Header("-Awaiting Part")]
	public GameObject joinPart;

	public GameObject waitingPart;

	public GameObject acceptNewMember;

	public GameObject declineNewMember;

	public GameObject cannotJoinPart;

	[Header("-Reputation Points")]
	public GameObject reputationPointsPart;

	public UILabel reputationPointsNumber;

	[Header("-Squad Points")]
	public GameObject squadPointsPart;

	public UILabel squadPointsNumber;

	[Header("-Army Power")]
	public UILabel armyPowerNumber;

	[Header("-Medals")]
	public UISprite leagueIcon;

	public UILabel skillNumber;

	[Header("-Kick")]
	public GameObject kickPart;

	public GameObject kickButton;

	public UILabel kickLabel;

	[Header("-Leave")]
	public GameObject leavePart;

	public GameObject leaveButton;

	public UILabel leaveLabel;

	[Header("Invite Record")]
	public GameObject emptyPart;

	public GameObject buttonInvite;

	[Header("Summary Record")]
	public GameObject summaryPart;

	public UITable summaryTable;

	public UILabel summaryFirstLabel;

	public UILabel summarySecondLabel;

	public GameObject summaryMaxSquadSizePart;

	private DatabasePlayer mSquadMember;

	internal void InitEmpty()
	{
		buttonSetter.SetWidth(UIRoot.list[0].activeWidth - 120f);
		memberPart.SetActive(value: false);
		emptyPart.SetActive(value: true);
		summaryPart.SetActive(value: false);
		mSquadMember = null;
	}

	internal void InitSummary(int squadRank, int nextRankSizeIncrease)
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		buttonSetter.SetWidth(activeWidth - 120f);
		memberPart.SetActive(value: false);
		emptyPart.SetActive(value: false);
		summaryPart.SetActive(value: true);
		mSquadMember = null;
		summaryTable.gameObject.SetActive(nextRankSizeIncrease > 0);
		summaryMaxSquadSizePart.SetActive(nextRankSizeIncrease < 1);
		if (nextRankSizeIncrease > 0)
		{
			summaryFirstLabel.text = Localization.Localize("ID_SQUADSIZEINCREASEATSQUADRANK");
			summarySecondLabel.text = Localization.LocalizeFormat("ID_CURRENTRANK", nextRankSizeIncrease, Colours.stringGrayLight, squadRank);
			float num = activeWidth - 430f;
			float num2 = summaryFirstLabel.relativeSize.x + summarySecondLabel.relativeSize.x;
			float num3 = Mathf.Clamp(num / num2, 20f, 37f);
			summaryFirstLabel.transform.localScale = new Vector3(num3, num3, 1f);
			summarySecondLabel.transform.localScale = new Vector3(num3, num3, 1f);
			summaryTable.repositionNow = true;
			summaryTable.onReposition = delegate
			{
				float val = 0f - summaryTable.padding.x - (summarySecondLabel.transform.parent.transform.localPosition.x - summaryTable.padding.x) / 2f;
				summaryTable.transform.localPosition = summaryTable.transform.localPosition.ReplaceX(val);
			};
		}
	}

	internal void InitMember(DatabasePlayer squadMember, int pos)
	{
		SetKickAndLeaveLabels();
		float num = UIRoot.list[0].activeWidth - 120f;
		int num2 = (int)(num - 1470f) + 41;
		buttonSetter.SetWidth(num);
		memberPart.SetActive(value: true);
		emptyPart.SetActive(value: false);
		summaryPart.SetActive(value: false);
		mSquadMember = squadMember;
		highlight.gameObject.SetActive(squadMember.id == GameLoginManager.currentPlayer.id);
		avatar.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(squadMember);
		string text = GameVariables.CountryCodeSpriteName(squadMember.country);
		bool flag = !string.IsNullOrEmpty(text);
		countryIcon.gameObject.SetActive(flag);
		if (flag)
		{
			countryIcon.spriteName = text;
		}
		position.text = MiscTools.FormatNumberToOrdinalPoint(pos);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(squadMember.level);
		rankIcon.spriteName = levelDefinition.iconName;
		rankNumber.text = levelDefinition.displayString;
		bool flag2 = squadMember.warArenaCrown != WarArenaCrown.None;
		crownPart.SetActive(flag2);
		if (flag2)
		{
			num2 -= 40;
			crownIcon.spriteName = GameVariables.crownSprites[squadMember.warArenaCrown];
			crownIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(30f / crownIcon.transform.localScale.x, 40f / crownIcon.transform.localScale.y);
			crownIcon.transform.localScale = crownIcon.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag3 = true;
		if (flag3)
		{
			num2 -= 41;
		}
		statusPart.SetActive(flag3);
		statusIcon.color = GameVariables.playerStatus[squadMember.GetRealStatus()].Value2;
		nickLabel.text = squadMember.name;
		TweenColor.Begin(nickLabel.gameObject, 0f, Color.white);
		MiscTools.SetUILabelRescale(nickLabel, 37f, 20f, num2);
		nameTable.repositionNow = true;
		playerButton.center = new Vector3((float)num2 / 2f, playerButton.center.y, playerButton.center.z);
		playerButton.size = new Vector3((float)num2 + 20f, playerButton.size.y, playerButton.size.z);
		if (squadMember.awaitingSquadMember)
		{
			SetAwaitingPlayer();
		}
		else
		{
			SetFunction(squadMember);
			reputationPointsPart.SetActive(value: true);
			reputationPointsNumber.text = MiscTools.FormatBigNumber(squadMember.reputation);
			squadPointsPart.SetActive(value: true);
			squadPointsNumber.text = MiscTools.FormatBigNumber(squadMember.squadPoints);
		}
		armyPowerNumber.text = MiscTools.FormatBigNumber(squadMember.armyPowerX10);
		MiscTools.SetUILabelRescale(armyPowerNumber, 42f, 28f, 113);
		SetMedalsPart(squadMember);
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener3 = UIEventListener.Get(playerButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
	}

	private void SetAwaitingPlayer()
	{
		functionLabel.text = Localization.Localize("ID_PENDING");
		AwaitingState awaitingState = Singleton<AwaitingSquadMembersManager>.instance.MemberState(mSquadMember.id);
		joinPart.SetActive(awaitingState == AwaitingState.Response);
		waitingPart.SetActive(awaitingState == AwaitingState.Waiting);
		cannotJoinPart.SetActive(awaitingState == AwaitingState.Error);
		squadMemberPart.SetActive(value: false);
		squadPointsPart.SetActive(value: false);
		reputationPointsPart.SetActive(value: false);
		kickPart.SetActive(value: false);
		leavePart.SetActive(value: false);
	}

	private void SetFunction(DatabasePlayer squadMember)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (squadMember.id == currentPlayer.id && squadMember.squadRank != currentPlayer.squadRank)
		{
			Debug.LogError($"Current player squadRank:{currentPlayer.squadRank} and info in all members squadRank:{squadMember.squadRank}");
		}
		int num = 0;
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(currentPlayer.squadName, ommitTime: true);
		if (squad != null)
		{
			num = squad.size;
		}
		functionLabel.text = Localization.Localize(GameVariables.squadFunctions[squadMember.squadRank]);
		squadMemberPart.SetActive(value: true);
		joinPart.SetActive(value: false);
		waitingPart.SetActive(value: false);
		cannotJoinPart.SetActive(value: false);
		bool flag = squadMember.id == currentPlayer.id;
		bool flag2 = num > 1;
		int num2 = ((currentPlayer.squadRank == SquadRank.Coleader) ? 1 : 0);
		bool flag3 = MiscTools.CompareSquadRanks(squadMember.squadRank, currentPlayer.squadRank) < 0;
		bool flag4 = MiscTools.CompareSquadRanks(squadMember.squadRank, currentPlayer.squadRank) < num2;
		bool flag5 = MiscTools.CompareSquadRanks(squadMember.squadRank, SquadRank.Member) > 0;
		bool flag6 = MiscTools.CompareSquadRanks(squadMember.squadRank, SquadRank.Coleader) < 0;
		bool flag7 = flag5 && flag6;
		bool flag8 = flag2 && currentPlayer.squadRank == SquadRank.Leader;
		bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
		changeLeaderShip.SetActive(flag && flag8);
		promoteButton.SetActive(!flag && flag6 && flag3 && !flag7);
		demoteButton.SetActive(!flag && flag5 && flag4 && !flag7);
		promoteButtonSmall.SetActive(!flag && flag6 && flag3 && flag7);
		demoteButtonSmall.SetActive(!flag && flag5 && flag4 && flag7);
		kickPart.SetActive(!flag && !isSquadWarsProcessing && flag4);
		leavePart.SetActive(flag && !isSquadWarsProcessing);
		if (GuiScreenSingle<SquadScreen>.instance.memberContent.IsPlayerWaitingForServerResponse(mSquadMember.id))
		{
			ShowWaitingFunction();
		}
	}

	private void ShowWaitingFunction()
	{
		changeLeaderShip.SetActive(value: false);
		promoteButton.SetActive(value: false);
		demoteButton.SetActive(value: false);
		promoteButtonSmall.SetActive(value: false);
		demoteButtonSmall.SetActive(value: false);
		leavePart.SetActive(value: false);
		kickPart.SetActive(value: false);
		waitingPart.gameObject.SetActive(value: true);
		waitingPart.transform.localPosition = waitingPart.transform.localPosition.ReplaceX(-120f);
	}

	private void SetMedalsPart(DatabasePlayer squadMember)
	{
		bool isInLeague = squadMember.isInLeague;
		skillNumber.text = MiscTools.FormatBigNumber(squadMember.skill);
		if (squadMember.isInBeginnersLeague)
		{
			leagueIcon.alpha = 1f;
			leagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(squadMember.beginnersLeague);
			leagueIcon.MakePixelPerfect();
			leagueIcon.transform.localScale = leagueIcon.transform.localScale.MultiplyXY(0.634f);
		}
		else if (squadMember.leagueTier != League.NoLeague)
		{
			leagueIcon.alpha = ((!isInLeague) ? 0.5f : 1f);
			leagueIcon.spriteName = GameVariables.leagueNames[squadMember.leagueTier].Value2;
			leagueIcon.MakePixelPerfect();
			leagueIcon.transform.localScale = leagueIcon.transform.localScale.MultiplyXY(0.634f);
		}
		else
		{
			leagueIcon.alpha = 0f;
		}
	}

	private void SetKickAndLeaveLabels()
	{
		kickLabel.text = Localization.Localize("ID_KICKPLAYER");
		int width = ((!kickLabel.text.Contains("\n")) ? 120 : 240);
		MiscTools.SetUILabelRescale(kickLabel, 30f, 20f, width);
		leaveLabel.text = Localization.Localize("ID_LEAVESQUAD");
		int width2 = ((!leaveLabel.text.Contains("\n")) ? 120 : 240);
		MiscTools.SetUILabelRescale(leaveLabel, 30f, 20f, width2);
	}

	private void ChangeLeaderShipClick(GameObject go)
	{
		if (mSquadMember == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.memberContent.SkipListUpdate();
		SelectSquadLeaderDialog.ShowSelectNewSquadLeader(delegate(DatabasePlayer player, bool selected)
		{
			if (selected)
			{
				ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_PROMOTETOLEADER"), Localization.LocalizeFormat("ID_CONFIRM_PROMOTETOLEADER_TEXT", player.name), delegate(ConfirmDialog dialog, bool result)
				{
					if (result)
					{
						GuiScreenSingle<SquadScreen>.instance.memberContent.SkipListUpdate();
						GuiScreenSingle<SquadScreen>.instance.memberContent.AddAction(DatabaseAction.PromotePlayerToFounder, GameLoginManager.currentPlayer.id);
						ShowWaitingFunction();
						GuiScreenSingle<SquadScreen>.instance.memberContent.AddAction(DatabaseAction.PromotePlayerToFounder, player.id);
						GuiScreenSingle<SquadScreen>.instance.memberContent.UpdateShownRecord(player.id);
						Singleton<BeanstalkServerManager>.instance.PromotePlayerToFounder(player);
					}
				}, 0f);
			}
		}, GuiScreenSingle<SquadScreen>.instance.memberContent.draggablePanel);
	}

	private void DemoteButtonClick(GameObject go)
	{
		if (mSquadMember == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.memberContent.SkipListUpdate();
		GuiScreenSingle<SquadScreen>.instance.memberContent.AddAction(DatabaseAction.DemotePlayer, mSquadMember.id);
		ShowWaitingFunction();
		Singleton<BeanstalkServerManager>.instance.DemotePlayer(mSquadMember);
	}

	private void PromoteButtonClick(GameObject go)
	{
		if (mSquadMember == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		if (mSquadMember.squadRank == SquadRank.Veteran && !GuiScreenSingle<SquadScreen>.instance.memberContent.canBePromotedToColeader)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_PROMOTEERROR_TEXT"), Localization.Localize("ID_WARNING_PROMOTEERROR"), 0f, null, string.Empty);
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.memberContent.SkipListUpdate();
		GuiScreenSingle<SquadScreen>.instance.memberContent.AddAction(DatabaseAction.PromotePlayer, mSquadMember.id);
		ShowWaitingFunction();
		Singleton<BeanstalkServerManager>.instance.PromotePlayer(mSquadMember);
	}

	private void YesAcceptClick(GameObject go)
	{
		if (mSquadMember == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.memberContent.SkipListUpdate();
		joinPart.SetActive(value: false);
		waitingPart.SetActive(value: true);
		waitingPart.transform.localPosition = waitingPart.transform.localPosition.ReplaceX(0f);
		Singleton<AwaitingSquadMembersManager>.instance.YesClick(mSquadMember.id);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Admit_Member");
	}

	private void NoDeclineClick(GameObject go)
	{
		if (mSquadMember == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.memberContent.SkipListUpdate();
		joinPart.SetActive(value: false);
		waitingPart.SetActive(value: true);
		waitingPart.transform.localPosition = waitingPart.transform.localPosition.ReplaceX(0f);
		Singleton<AwaitingSquadMembersManager>.instance.NoClick(mSquadMember.id);
	}

	private void KickClick(GameObject go)
	{
		if (mSquadMember == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		string memberId = mSquadMember.id;
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_KICKPLAYER"), Localization.LocalizeFormat("ID_CONFIRM_KICKPLAYER_TEXT", mSquadMember.name), delegate(ConfirmDialog dialog, bool result)
		{
			if (result)
			{
				GuiScreenSingle<SquadScreen>.instance.memberContent.SkipListUpdate();
				GuiScreenSingle<SquadScreen>.instance.memberContent.AddAction(DatabaseAction.KickPlayer, memberId);
				ShowWaitingFunction();
				Singleton<BeanstalkServerManager>.instance.KickPlayer(memberId);
				Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Remove_Member");
			}
		}, 0f);
	}

	private void LeaveClick(GameObject go)
	{
		if (mSquadMember == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (mSquadMember.id != currentPlayer.id)
		{
			Debug.LogError("Wrong player id on squadMember, not leaving squad!");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.memberContent.SkipListUpdate();
		GuiScreenSingle<SquadScreen>.instance.LeaveSquadClick(go);
	}

	private void ShowPlayer(GameObject go)
	{
		if (!string.IsNullOrEmpty(mSquadMember.name))
		{
			TweenColor tweenColor = TweenColor.Begin(nickLabel.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mSquadMember.name, mSquadMember.id);
		}
	}

	private void ShowPlayerIcon(GameObject go)
	{
		if (!string.IsNullOrEmpty(mSquadMember.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mSquadMember.name, mSquadMember.id);
		}
	}

	public void FreeTexture()
	{
		if (mSquadMember != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mSquadMember.id);
			mSquadMember = null;
		}
	}

	private void OnPlayerTextureCreated(string playerID, Texture2D playerTexture, bool useBackground)
	{
		if (mSquadMember != null && mSquadMember.id == playerID)
		{
			avatar.avatar = playerTexture;
			avatar.UpdateIcon();
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		UIEventListener uIEventListener = UIEventListener.Get(changeLeaderShip);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ChangeLeaderShipClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(promoteButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PromoteButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(promoteButtonSmall);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PromoteButtonClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(demoteButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DemoteButtonClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(demoteButtonSmall);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(DemoteButtonClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(acceptNewMember);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(YesAcceptClick));
		UIEventListener uIEventListener7 = UIEventListener.Get(declineNewMember);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(NoDeclineClick));
		UIEventListener uIEventListener8 = UIEventListener.Get(kickButton);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(KickClick));
		UIEventListener uIEventListener9 = UIEventListener.Get(leaveButton);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(LeaveClick));
		UIEventListener uIEventListener10 = UIEventListener.Get(buttonInvite);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, (UIEventListener.VoidDelegate)delegate(GameObject go)
		{
			GuiScreenSingle<SquadScreen>.instance.InviteToSquadClick(go);
		});
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener.Get(changeLeaderShip).onClick = null;
		UIEventListener.Get(promoteButton).onClick = null;
		UIEventListener.Get(promoteButtonSmall).onClick = null;
		UIEventListener.Get(demoteButton).onClick = null;
		UIEventListener.Get(demoteButtonSmall).onClick = null;
		UIEventListener.Get(acceptNewMember).onClick = null;
		UIEventListener.Get(declineNewMember).onClick = null;
		UIEventListener.Get(kickButton).onClick = null;
		UIEventListener.Get(leaveButton).onClick = null;
		UIEventListener.Get(buttonInvite).onClick = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		FreeTexture();
	}
}
