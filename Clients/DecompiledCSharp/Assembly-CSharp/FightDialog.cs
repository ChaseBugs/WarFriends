using System;
using System.Collections;
using UnityEngine;

public class FightDialog : GuiElementSingle<FightDialog>, IGuiDialog
{
	private enum Type
	{
		Battle,
		COOP,
		SquadInvite
	}

	[Header("Header")]
	public UIButton closeButton;

	public UISprite background;

	public UILabel title;

	public GameObject headerHeroicCoop;

	[Header("Core")]
	public UILabel opponentName;

	[Header("-Battle")]
	public GameObject fightPart;

	public UILabel opponentArmyPower;

	public UILabel opponentSkill;

	[Header("-Coop")]
	public GameObject coopPart;

	public GameObject missionHeroicPart;

	public GameObject missionNumberParent;

	public UILabel missionNumber;

	public UILabel missionName;

	public UILabel missionTask;

	public UILabel missionTimeLimit;

	public MissionRewardsBox[] missionRewards;

	[Header("-Squad Invite")]
	public GameObject invitePart;

	public UITexture squadIconTexture;

	public UILabel squadNameLabel;

	public UILabel squadDescription;

	public UILabel squadMembers;

	public UILabel squadLevel;

	public UILabel squadSkill;

	public UILabel squadRequiredSkill;

	[Header("Bottom")]
	public GameObject buttonPart;

	public UILabel infoTextDown;

	[Header("-Fight Buttton")]
	public UIButton fightButton;

	public UILabel fightLabel;

	public UISprite dogtagInFight;

	public GameObject fightButtonOverlay;

	public GameObject fightButtonWaiting;

	[Header("-Postphone Button")]
	public UIButton postponeButton;

	public BoxCollider postponeColl;

	public UISprite postponeBackground;

	public UILabel postponeLabel;

	[Header("-Decline Button")]
	public UIButton declineButton;

	private DatabaseMessage mMessage;

	private ChallengeMessage mChallenge;

	private SquadInviteMessage mInvite;

	private Type mType;

	private bool mHeroic;

	private float mRemainingSeconds;

	private RadicalRoutine mUpdate;

	private bool mSquadDataLoaded;

	public static void ShowFightDialog(DatabaseMessage message, float delay = 0f)
	{
		FightDialog dialog = GuiElementSingle<FightDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(delegate
		{
			dialog.mMessage = message;
			ChallengeMessage challengeMessage = message as ChallengeMessage;
			if (challengeMessage != null)
			{
				dialog.mChallenge = challengeMessage;
				dialog.mType = (challengeMessage.isCoop ? Type.COOP : Type.Battle);
			}
			dialog.mHeroic = challengeMessage != null && challengeMessage.isCoop && challengeMessage.isHeroic;
			if (message is SquadInviteMessage squadInviteMessage)
			{
				dialog.mInvite = squadInviteMessage;
				dialog.mType = Type.SquadInvite;
			}
			Singleton<GuiManager>.instance.ShowDialog(dialog, 0f);
		}, delay);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(fightButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FightClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(postponeButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PostpooneClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(declineButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DeclineClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (isShowed && action == DatabaseAction.GetSquadDetails && !string.IsNullOrEmpty(squadNameLabel.text))
			{
				fightButtonWaiting.SetActive(value: false);
				DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(squadNameLabel.text);
				mSquadDataLoaded = true;
				bool active = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing || squad == null;
				fightButtonOverlay.SetActive(active);
				if (squad != null && squadNameLabel.text == squad.name)
				{
					if (mMessage is SquadInviteMessage squadInviteMessage)
					{
						squadInviteMessage.squad = squad;
					}
					FillSquadInfo(squad);
				}
			}
		};
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.SquadWarProcessingChanged = (Action)Delegate.Combine(serverResultsCache.SquadWarProcessingChanged, (Action)delegate
		{
			if (isShowed && mSquadDataLoaded)
			{
				bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
				fightButtonOverlay.SetActive(isSquadWarsProcessing);
			}
		});
	}

	private void FightClick(GameObject go)
	{
		if (isShowed)
		{
			if (mType == Type.SquadInvite)
			{
				InviteAcceptClick();
			}
			else
			{
				FightAcceptClick();
			}
		}
	}

	private void CloseClick(GameObject go)
	{
		if (isShowed)
		{
			if (mType == Type.SquadInvite)
			{
				InvitePostphoneClick();
			}
			else
			{
				FightPostphoneClick();
			}
		}
	}

	private void PostpooneClick(GameObject go)
	{
		if (isShowed)
		{
			if (mType == Type.SquadInvite)
			{
				InviteDeclineClick();
			}
			else
			{
				FightPostphoneClick();
			}
		}
	}

	private void DeclineClick(GameObject go)
	{
		if (isShowed && mType != Type.SquadInvite)
		{
			FightDeclineClick();
		}
	}

	private void FightAcceptClick()
	{
		if (mRemainingSeconds <= 0f)
		{
			mMessage.Ignore();
			return;
		}
		if (!Singleton<DogTagManager>.instance.CanUseDogtags(1))
		{
			HideDialog();
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessageWithoutNotification(mMessage);
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, fadeOutTime + 0.1f);
			return;
		}
		HideDialog();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		Debug.Log($"Accept Message {mChallenge.gameType}");
		if (mChallenge.gameType == GameController.GameType.DeathMatch)
		{
			Debug.Log("Start DeathMatch");
			if (!Singleton<GameController>.instance.SetChallenge(mChallenge))
			{
				mMessage.Ignore();
				return;
			}
			Singleton<GameController>.instance.StartHostMultiplayer();
		}
		if (mChallenge.gameType == GameController.GameType.Coop)
		{
			MissionsManager.instance.indexMissionToStart = mChallenge.misssionNumber;
			Singleton<MapManager>.instance.SelectCurrentMap(MissionsManager.instance.currentMission.map);
			if (!Singleton<GameController>.instance.SetChallenge(mChallenge))
			{
				mMessage.Ignore();
				return;
			}
			MissionsManager.instance.currentMission.OpenMission(null, isInvite: true, isRematch: false, mHeroic);
		}
		Singleton<BeanstalkServerManager>.instance.AcceptChallenge(mChallenge);
	}

	private void FightPostphoneClick()
	{
		HideDialog();
		if (mRemainingSeconds <= 0f)
		{
			mMessage.Ignore();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessageWithoutNotification(mMessage);
		}
	}

	private void FightDeclineClick()
	{
		HideDialog();
		mMessage.Ignore();
	}

	private void InviteAcceptClick()
	{
		if (mInvite != null)
		{
			DatabaseSquad squad = mInvite.squad;
			if (squad.skillRequirement > GameLoginManager.currentPlayer.skill)
			{
				GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(squad.name, squad.skillRequirement, GameLoginManager.currentPlayer.skill);
				GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessageWithoutNotification(mMessage);
			}
			else if (squad.GetPlacesLeft() <= 0)
			{
				ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADFULL"), Localization.LocalizeFormat("ID_CONFIRM_SQUADFULL_TEXT", Colours.stringBlue, squad.name, Colours.stringWhite), 0f);
				GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessageWithoutNotification(mMessage);
			}
			else
			{
				mMessage.Confirm();
			}
		}
		HideDialog();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	private void InvitePostphoneClick()
	{
		HideDialog();
		DatabaseSquad squad = mInvite.squad;
		if (!squad.IsFull() && GameLoginManager.currentPlayer.skill >= squad.skillRequirement)
		{
			mMessage.Ignore();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessageWithoutNotification(mMessage);
		}
	}

	private void InviteDeclineClick()
	{
		HideDialog();
		mMessage.Ignore();
	}

	public override void InitGUIValues()
	{
		mSquadDataLoaded = false;
		SetUpFightButton();
		if (mType == Type.SquadInvite)
		{
			mRemainingSeconds = 0f;
			SetUpInfoTextDown();
			SetUpInvite();
			opponentName.text = string.Format("{0} {1}{2}", mInvite.playerThatSendInvite.name, Colours.stringWhite, Localization.Localize("ID_INVITEDYOUTOSQUAD"));
			DatabaseSquad databaseSquad = mInvite.squad;
			if (!string.IsNullOrEmpty(databaseSquad.name))
			{
				DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(databaseSquad.name);
				if (squad != null)
				{
					databaseSquad = squad;
					mSquadDataLoaded = true;
					fightButtonWaiting.SetActive(value: false);
					bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
					fightButtonOverlay.SetActive(isSquadWarsProcessing);
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetSquadDetails(databaseSquad.name);
				}
			}
			FillSquadInfo(databaseSquad);
		}
		else
		{
			AssignmentsManager.instance.GetAssignmentsAfterStarterEnd();
			int num = Mathf.Clamp(Singleton<BeanstalkServerManager>.instance.currentTimestamp - mMessage.messageTime, 0, int.MaxValue);
			int num2 = 120;
			if (num > num2)
			{
				Debug.Log($"Received old game invite ( > {num2} seconds). Not showing dialog. Opponent = {mChallenge.otherPlayer.name}");
				mMessage.Ignore();
				return;
			}
			mRemainingSeconds = num2 - num;
			StartUpdate();
			SetUpFightButton();
			if (mType == Type.Battle)
			{
				SetUpFight();
				if (mChallenge.otherPlayer != null)
				{
					opponentName.text = string.Format("{0}{1}", mChallenge.otherPlayer.name, Localization.LocalizeFormat("ID_INVITEDYOUTOFIGHT", Colours.stringWhite));
					opponentArmyPower.text = MiscTools.FormatBigNumber(mChallenge.otherPlayer.armyPowerX10);
					opponentSkill.text = MiscTools.FormatBigNumber(mChallenge.otherPlayer.skill);
				}
				else
				{
					opponentName.text = string.Empty;
				}
			}
			else
			{
				SetUpCoop();
				if (mChallenge.otherPlayer != null)
				{
					opponentName.text = string.Format("{0}{1}", mChallenge.otherPlayer.name, Localization.LocalizeFormat((!mHeroic) ? "ID_INVITEDYOUTOCOOP" : "ID_INVITEDYOUTOCOOPHEROIC", Colours.stringWhite, Colours.stringGoldHeroic));
				}
				else
				{
					opponentName.text = string.Empty;
				}
				Mission mission = MissionsManager.instance.GetMission(mChallenge.misssionNumber);
				missionNumber.text = mission.number.ToString();
				missionName.text = Localization.Localize(GameVariables.missionDialogTranslationIds[mission.missionType].Value1);
				MiscTools.SetUILabelRescale(missionName, 47f, 20f, (!mHeroic) ? 500 : 440);
				missionTask.text = Localization.LocalizeFormat(GameVariables.missionDialogTranslationIds[mission.missionType].Value2, mission.GetMissionObjective());
				missionTimeLimit.text = ((mission.missionType != Mission.MissionType.Survive) ? string.Format("{0} {1}{2}", Localization.Localize("ID_TIMELIMIT"), Colours.stringWhite, MiscTools.PrintableTimeTwoDigits(mission.maxTimeForMission)) : string.Empty);
				SetUpMissionRewards(mission);
			}
		}
		MiscTools.SetUILabelRescale(opponentName, 51f, 30f);
	}

	private void FillSquadInfo(DatabaseSquad squad)
	{
		if (!string.IsNullOrEmpty(squad.name))
		{
			squadIconTexture.mainTexture = Resources.Load<Texture>("SquadIcons/" + squad.icon);
			squadIconTexture.MakePixelPerfect();
			squadIconTexture.transform.localScale = squadIconTexture.transform.localScale.MultiplyXY(0.8f);
			SetUpSquadName(squad.name);
			squadDescription.text = ((!string.IsNullOrEmpty(squad.message)) ? squad.message : Localization.Localize("ID_NOSQUADMESSAGE"));
			int num = squad.size + squad.GetPlacesLeft();
			squadMembers.text = Localization.LocalizeFormat("ID_SQUADMEMBERSLOWER", squad.size, num);
			squadLevel.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADLEVEL"), Colours.stringBlue, squad.rank);
			squadSkill.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADMEDALS"), Colours.stringBlue, MiscTools.FormatBigNumber(squad.skill));
			squadRequiredSkill.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADREQUIREDMEDALS"), Colours.stringBlue, MiscTools.FormatBigNumber(squad.skillRequirement));
			MiscTools.SetUILabelRescale(squadRequiredSkill, 32f, 20f, 450);
			float x = squadRequiredSkill.transform.localScale.x;
			MiscTools.SetUILabelRescale(squadSkill, x, 20f, 450);
			MiscTools.SetUILabelRescale(squadLevel, x, 20f, 450);
		}
	}

	private void SetUpSquadName(string newName)
	{
		squadNameLabel.text = newName;
		MiscTools.SetUILabelRescale(squadNameLabel, 55f, 32f, 400);
	}

	private void SetUpInvite()
	{
		background.transform.localScale = background.transform.localScale.ReplaceY(942f);
		buttonPart.transform.localPosition = buttonPart.transform.localPosition.ReplaceY(-233f);
		headerHeroicCoop.SetActive(value: false);
		fightPart.SetActive(value: false);
		coopPart.SetActive(value: false);
		invitePart.SetActive(value: true);
		title.text = Localization.Localize("ID_SQUADINVITE");
		MiscTools.SetUILabelRescale(title, 89f, 44f, 760);
		postponeLabel.text = Localization.Localize("ID_DECLINE");
		postponeButton.transform.localPosition = postponeButton.transform.localPosition.ReplaceX(-288f);
		postponeBackground.transform.localScale = postponeBackground.transform.localScale.ReplaceX(484f);
		postponeColl.size = postponeColl.size.ReplaceX(540f);
		declineButton.gameObject.SetActive(value: false);
		fightButtonOverlay.SetActive(value: true);
		fightButtonWaiting.SetActive(value: true);
	}

	private void SetUpFight()
	{
		background.transform.localScale = background.transform.localScale.ReplaceY(822f);
		buttonPart.transform.localPosition = buttonPart.transform.localPosition.ReplaceY(-133f);
		headerHeroicCoop.SetActive(value: false);
		fightPart.SetActive(value: true);
		coopPart.SetActive(value: false);
		invitePart.SetActive(value: false);
		title.text = Localization.Localize("ID_GAMEINVITE");
		MiscTools.SetUILabelRescale(title, 89f, 44f, 760);
		postponeLabel.text = Localization.Localize("ID_POSTPONE");
		postponeButton.transform.localPosition = postponeButton.transform.localPosition.ReplaceX(-206f);
		postponeBackground.transform.localScale = postponeBackground.transform.localScale.ReplaceX(380f);
		postponeColl.size = postponeColl.size.ReplaceX(400f);
		declineButton.gameObject.SetActive(value: true);
		fightButtonOverlay.SetActive(value: false);
		fightButtonWaiting.SetActive(value: false);
	}

	private void SetUpCoop()
	{
		background.transform.localScale = background.transform.localScale.ReplaceY(942f);
		buttonPart.transform.localPosition = buttonPart.transform.localPosition.ReplaceY(-233f);
		headerHeroicCoop.SetActive(mHeroic);
		fightPart.SetActive(value: false);
		coopPart.SetActive(value: true);
		invitePart.SetActive(value: false);
		title.text = Localization.Localize("ID_GAMEINVITE");
		MiscTools.SetUILabelRescale(title, 89f, (!mHeroic) ? 44f : 20f, (!mHeroic) ? 760 : 660);
		postponeLabel.text = Localization.Localize("ID_POSTPONE");
		postponeButton.transform.localPosition = postponeButton.transform.localPosition.ReplaceX(-206f);
		postponeBackground.transform.localScale = postponeBackground.transform.localScale.ReplaceX(380f);
		postponeColl.size = postponeColl.size.ReplaceX(400f);
		declineButton.gameObject.SetActive(value: true);
		fightButtonOverlay.SetActive(value: false);
		fightButtonWaiting.SetActive(value: false);
		missionHeroicPart.SetActive(mHeroic);
		missionNumberParent.transform.localPosition = missionNumberParent.transform.localPosition.ReplaceX((!mHeroic) ? 33.5f : 98f);
		missionName.transform.localPosition = missionName.transform.localPosition.ReplaceX((!mHeroic) ? 96f : 160f);
		missionName.color = ((!mHeroic) ? Colours.blue : Colours.goldHeroic);
		missionTask.color = ((!mHeroic) ? Colours.blue : Colours.goldHeroic);
		missionTimeLimit.color = ((!mHeroic) ? Colours.blue : Colours.goldHeroic);
	}

	private void SetUpMissionRewards(Mission mission)
	{
		bool flag = false;
		bool flag2 = false;
		MissionRewardsBox[] array = missionRewards;
		foreach (MissionRewardsBox missionRewardsBox in array)
		{
			if (!flag)
			{
				flag = true;
				if (mission.rewardWB > 0)
				{
					missionRewardsBox.InitializeWarbucks(mission.rewardWBCompleted);
					continue;
				}
			}
			if (!flag2)
			{
				flag2 = true;
				if (mission.rewardXP > 0)
				{
					missionRewardsBox.InitializeXP(mission.rewardXPCompleted);
					continue;
				}
			}
			missionRewardsBox.Hide();
		}
	}

	private void SetUpInfoTextDown()
	{
		if (mType == Type.SquadInvite)
		{
			infoTextDown.text = string.Empty;
		}
		else if (mRemainingSeconds > 0f)
		{
			infoTextDown.text = string.Format("{0} {1}", Localization.Localize("ID_INVITEWILLBEACTIVEFOR"), MiscTools.PrintableTimeDescription(mRemainingSeconds).ToUpper());
		}
		else
		{
			infoTextDown.text = Localization.Localize("ID_INVITEISINACTIVE");
		}
	}

	private void SetUpFightButton()
	{
		fightLabel.text = Localization.Localize((mType != Type.Battle) ? "ID_ACCEPT" : "ID_FIGHT");
		fightLabel.transform.localPosition = fightLabel.transform.localPosition.ReplaceX((mType == Type.COOP) ? (-52f) : 0f);
		MiscTools.SetUILabelRescale(fightLabel, 62f, 31f, (mType == Type.COOP) ? 370 : 470);
		dogtagInFight.alpha = ((mType == Type.COOP) ? 1f : 0f);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		squadIconTexture.mainTexture = null;
		StopUpdate();
	}

	public void StartUpdate()
	{
		StopUpdate();
		mUpdate = RadicalRoutine.Create(AlternativeUpdate());
		StartCoroutine(RadicalRoutine.Run(mUpdate.enumerator));
	}

	private void StopUpdate()
	{
		if (mUpdate != null)
		{
			mUpdate.Cancel();
			mUpdate = null;
		}
	}

	private IEnumerator AlternativeUpdate()
	{
		while (isShowed)
		{
			yield return new WaitForRealSeconds(0.333f);
			mRemainingSeconds -= 0.333f;
			SetUpInfoTextDown();
			if (mRemainingSeconds <= 0f)
			{
				mRemainingSeconds = 0f;
				mMessage.Ignore();
				fightButtonOverlay.SetActive(value: true);
				break;
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(closeButton.gameObject);
	}
}
