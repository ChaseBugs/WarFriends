using System;
using UnityEngine;

public class SquadRecord : PoolableObject
{
	[Header("Size Setter")]
	public UIButtonSetter widthSetter;

	[Header("Left Part")]
	public UITexture squadIconTexture;

	public UILabel squadLevel;

	public UILabel squadName;

	public BoxCollider squadNameButton;

	public UILabel squadMembersCount;

	public GameObject privateSquad;

	[Header("Center Part")]
	public UILabel squadMedals;

	public UILabel squadRequiredMedals;

	[Header("Right Part")]
	public GameObject infoButton;

	public GameObject joinButton;

	public GameObject privateSquadRequest;

	private DatabaseSquad mSquad;

	internal void InitializeSquad(DatabaseSquad squad, float length)
	{
		mSquad = squad;
		widthSetter.SetWidth(length);
		squadIconTexture.mainTexture = Resources.Load<Texture>("SquadIcons/" + mSquad.icon);
		squadIconTexture.MakePixelPerfect();
		squadIconTexture.transform.localScale = squadIconTexture.transform.localScale.MultiplyXY(0.75f);
		squadLevel.text = mSquad.rank.ToString();
		squadName.text = ((!string.IsNullOrEmpty(mSquad.name)) ? mSquad.name : string.Empty);
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(mSquad.name))
		{
			squadName.text = "NULL";
		}
		MiscTools.SetUILabelRescale(squadName, 50f, 33f);
		squadMembersCount.text = Localization.LocalizeFormat("ID_SQUADMEMBERSLOWER", mSquad.size, mSquad.size + mSquad.GetPlacesLeft());
		privateSquad.SetActive(!mSquad.isPublic);
		squadMedals.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADMEDALS"), Colours.stringBlue, MiscTools.FormatBigNumber(mSquad.skill));
		squadRequiredMedals.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADREQUIREDMEDALS"), Colours.stringWhite, MiscTools.FormatBigNumber(mSquad.skillRequirement));
		int width = (int)length / 2 - 400;
		MiscTools.SetUILabelRescale(squadRequiredMedals, 37f, 20f, width);
		float y = squadRequiredMedals.transform.localScale.y;
		MiscTools.SetUILabelRescale(squadMedals, y, 20f, width);
		privateSquadRequest.SetActive(!mSquad.isPublic);
		float num = length - 1300f;
		squadNameButton.size = squadNameButton.size.ReplaceX(num);
		squadNameButton.center = squadNameButton.center.ReplaceX(num / 2f - 10f);
		UIEventListener uIEventListener = UIEventListener.Get(infoButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(InfoClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(infoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(InfoClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(joinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JoinClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(joinButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JoinClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(squadNameButton.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(NameClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(squadNameButton.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NameClick));
	}

	private void NameClick(GameObject go)
	{
		if (mSquad != null && !string.IsNullOrEmpty(mSquad.name))
		{
			TweenColor tweenColor = TweenColor.Begin(squadName.gameObject, GameVariables.durationOfNameButtonColor, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(mSquad.name);
		}
	}

	private void InfoClick(GameObject go)
	{
		if (mSquad != null && !string.IsNullOrEmpty(mSquad.name))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(mSquad.name);
		}
	}

	private void JoinClick(GameObject go)
	{
		if (mSquad == null || string.IsNullOrEmpty(mSquad.name) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && squadName.text == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Leader)
		{
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ALREADYLEADER"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			return;
		}
		if (mSquad.GetPlacesLeft() <= 0)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADFULL"), Localization.Localize("ID_CONFIRM_SQUADISALREADYFULL"), 0f);
		}
		else if (GameLoginManager.currentPlayer.skill < mSquad.skillRequirement)
		{
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(mSquad.name, mSquad.skillRequirement, GameLoginManager.currentPlayer.skill);
		}
		else if (!mSquad.isPublic)
		{
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(mSquad.name);
		}
		else
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_JOININGSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_JOININGSQUAD_TEXT", Colours.stringBlue, mSquad.name, Colours.stringWhite), delegate(ConfirmDialog dialog, bool result)
			{
				if (result)
				{
					Singleton<BeanstalkServerManager>.instance.JoinSquad(mSquad.name, string.Empty);
				}
			}, 0f);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Join_Request");
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		squadIconTexture.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(infoButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(InfoClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(joinButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JoinClick));
	}
}
