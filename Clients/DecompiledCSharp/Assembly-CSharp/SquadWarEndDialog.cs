using System;
using System.Collections.Generic;
using UnityEngine;

public class SquadWarEndDialog : GuiElementSingle<SquadWarEndDialog>, IGuiDialog
{
	[Header("Left Part")]
	public UITable squadInfoTable;

	public UITexture squadIcon;

	public UILabel squadName;

	public UILabel squadPosition;

	public UITable squadGoldRewardTabel;

	public UILabel squadGoldReward;

	public UILabel actionLabel;

	public UILabel squadDivisionLabel;

	public UISprite[] squadDivisionArrows;

	[Header("Left Bottom Part")]
	public UITable rewardTable;

	public UILabel yourSquadPoints;

	public UILabel yourGoldReward;

	[Header("Right List")]
	public UIDraggablePanel draggablePanel;

	public SquadWarEndMemberRecord memberPrefab;

	public UIPooledGrid memberGrid;

	[Header("Bottom Button")]
	public UIButton bottomButton;

	public UILabel buttonLabel;

	private string mSquadName;

	private string mSquadIcon;

	private int mSquadPosition;

	private int mGoldReward;

	private int mSquadsCount;

	private int mSquadDivision;

	private int mSquadNewDivision;

	private List<SquadWarsContent.SquadMemberInternal> mSquadMembersData;

	private DatabaseMessage mMessage;

	public void ShowDialog(string squadId, string squadEmblem, int squadPos, int squadsCount, int yourReward, int squadDivision, int squadNewDivision, List<DatabasePlayer> squadMembers, DatabaseMessage message)
	{
		squadMembers.Sort(SquadWarManager.instance.SortFunctionPlayers);
		mSquadName = squadId;
		mSquadIcon = squadEmblem;
		mSquadPosition = squadPos;
		mSquadsCount = squadsCount;
		mGoldReward = yourReward;
		mSquadDivision = squadDivision;
		mSquadNewDivision = squadNewDivision;
		mSquadMembersData = GuiScreenSingle<LeaguesScreen>.instance.squadWars.CreateSquadMembersList(squadMembers, squadDivision, squadsCount, squadPos);
		mMessage = message;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(bottomButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OkButtonClick));
		squadInfoTable.onReposition = delegate
		{
			float num = (squadName.transform.parent.localPosition.x - squadInfoTable.padding.x) / 2f + squadInfoTable.padding.x;
			squadInfoTable.transform.localPosition = squadInfoTable.transform.localPosition.ReplaceX(0f - num);
		};
		squadGoldRewardTabel.onReposition = delegate
		{
			float num = (squadGoldReward.transform.parent.localPosition.x - squadGoldRewardTabel.padding.x) / 2f + squadGoldRewardTabel.padding.x;
			squadGoldRewardTabel.transform.localPosition = squadGoldRewardTabel.transform.localPosition.ReplaceX(0f - num);
		};
		rewardTable.onReposition = delegate
		{
			float num = (yourGoldReward.transform.parent.localPosition.x - rewardTable.padding.x) / 2f + rewardTable.padding.x;
			rewardTable.transform.localPosition = rewardTable.transform.localPosition.ReplaceX(0f - num);
		};
	}

	private void OkButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (mMessage != null)
			{
				Debug.Log($"SquadWarEndDialog - Claiming gold: {mGoldReward}");
				Singleton<BeanstalkServerManager>.instance.ClaimReward(mMessage);
			}
			else
			{
				Debug.LogWarning("SquadWarEndDialog - Database message not set.");
			}
		}
	}

	public override void InitGUIValues()
	{
		bool flag = mGoldReward < 1;
		int num = mSquadNewDivision - mSquadDivision;
		int num2 = 0;
		if (mSquadMembersData != null)
		{
			int num3 = mSquadMembersData.FindIndex((SquadWarsContent.SquadMemberInternal data) => data.player != null && data.player.id == GameLoginManager.currentPlayer.id);
			if (num3 > -1)
			{
				num2 = mSquadMembersData[num3].player.squadPoints;
			}
		}
		int tier = MiscTools.SquadWarTier(mSquadPosition, mSquadsCount);
		int num4 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(tier, mSquadDivision);
		squadIcon.mainTexture = Resources.Load<Texture>("SquadIcons/" + mSquadIcon);
		squadIcon.MakePixelPerfect();
		squadIcon.transform.localScale = squadIcon.transform.localScale.MultiplyXY(0.5f);
		squadName.text = mSquadName;
		squadInfoTable.repositionNow = true;
		squadPosition.text = Localization.LocalizeFormat("ID_SQUADPLACE", MiscTools.FormatNumberToOrdinal(mSquadPosition).ToUpper());
		squadGoldReward.text = MiscTools.FormatBigNumber(num4);
		squadGoldRewardTabel.repositionNow = true;
		actionLabel.text = Localization.Localize((num > 0) ? "ID_PROMOTEDTODIVISION" : ((num >= 0) ? "ID_STAYINGINDIVISION" : "ID_DEMOTEDTODIVISION"));
		MiscTools.SetUILabelRescale(actionLabel, 37f, 20f, 288);
		squadDivisionLabel.text = string.Format("{0} {1}", Localization.Localize("ID_DIVISION"), 9 - mSquadNewDivision);
		for (int num5 = 0; num5 < squadDivisionArrows.Length; num5++)
		{
			squadDivisionArrows[num5].gameObject.SetActive(num5 < mSquadNewDivision);
		}
		yourSquadPoints.text = MiscTools.FormatBigNumber(num2);
		yourGoldReward.text = MiscTools.FormatBigNumber(mGoldReward);
		rewardTable.repositionNow = true;
		memberGrid.MakeEmpty();
		memberGrid.init(mSquadMembersData.Count, MemberInstantiate, MemberFree, draggablePanel);
		draggablePanel.AlignToPos(instant: false);
		buttonLabel.text = ((!flag) ? Localization.Localize("ID_AWESOME") : Localization.Localize("ID_CONTINUE"));
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.chatContent.draggablePanel.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.messageContent.draggablePanel.forceDrag = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		squadIcon.mainTexture = null;
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.chatContent.draggablePanel.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.messageContent.draggablePanel.forceDrag = true;
	}

	private Transform MemberInstantiate(int index)
	{
		if (index >= 0 && index < mSquadMembersData.Count)
		{
			SquadWarsContent.SquadMemberInternal squadMemberInternal = mSquadMembersData[index];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(memberPrefab, memberGrid.gameObject, string.Format("{0:3} {1}", index, (!squadMemberInternal.isHeader) ? "Squad Member" : "Header")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.Initialize(squadMemberInternal);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	private void MemberFree(Transform obj)
	{
		if (obj != null)
		{
			SquadWarEndMemberRecord component = obj.GetComponent<SquadWarEndMemberRecord>();
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
		OkButtonClick(bottomButton.gameObject);
	}
}
