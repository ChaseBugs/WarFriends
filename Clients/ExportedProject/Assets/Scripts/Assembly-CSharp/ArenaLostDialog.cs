using System;
using UnityEngine;

public class ArenaLostDialog : GuiElementSingle<ArenaLostDialog>, IGuiDialog
{
	[SerializeField]
	[Header("Core")]
	private UILabel mTitle;

	[SerializeField]
	private UILabel mDescription;

	[SerializeField]
	private UILabel mRewardTitle;

	[SerializeField]
	private UILabel mRewardScraps;

	[SerializeField]
	private GameObject mBottomButton;

	private int mWonBattles;

	private int mScrapsRewarded;

	private bool mArenaExpired;

	public void ShowDialog(bool arenaExpired, int wonBattles, int scrapsRewarded)
	{
		mArenaExpired = arenaExpired;
		mWonBattles = wonBattles;
		mScrapsRewarded = scrapsRewarded;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArenaScreen>.instance.arenaMode = ArenaScreen.ArenaScreenMode.EnterArena;
				GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		mTitle.text = Localization.Localize((!mArenaExpired) ? "ID_ARENALOST" : "ID_ARENAENDEDTITLE");
		mRewardTitle.text = Localization.Localize((!mArenaExpired) ? "ID_ARENALOSSREWARD" : "ID_ARENAPARTICIPATIONREWARD");
		if (mArenaExpired)
		{
			if (mWonBattles > 1)
			{
				mDescription.text = Localization.LocalizeFormat("ID_ARENAENDEDDESCRIPTIONXWINS", Colours.stringGreenArena, mWonBattles);
			}
			else
			{
				bool flag = mWonBattles < 1;
				mDescription.text = Localization.LocalizeFormat((!flag) ? "ID_ARENAENDEDDESCRIPTION1WIN" : "ID_ARENAENDEDDESCRIPTION0WINS", Colours.stringGreenArena);
			}
		}
		else if (mWonBattles > 1)
		{
			mDescription.text = Localization.LocalizeFormat("ID_THATWASGOODRUNSOLDIERXWINS", Colours.stringGreenArena, mWonBattles);
		}
		else
		{
			bool flag2 = mWonBattles < 1;
			mDescription.text = Localization.LocalizeFormat((!flag2) ? "ID_THATWASGOODRUNSOLDIER1WIN" : "ID_THATWASGOODRUNSOLDIER0WINS", Colours.stringGreenArena);
		}
		mRewardScraps.text = MiscTools.FormatBigNumber(mScrapsRewarded);
		Singleton<Wallet>.instance.AddScraps(mScrapsRewarded);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(mBottomButton);
	}
}
