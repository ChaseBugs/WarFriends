using System;
using UnityEngine;

public class ArenaHeroRecord : PoolableObject
{
	[Header("Core")]
	public UILabel positionAndName;

	public BoxCollider nameCollider;

	public UISprite winsIcon;

	public UISprite flawlessIcon;

	public UILabel winsLabel;

	[Header("Resize")]
	public UISprite background;

	public GameObject leftAnchor;

	public GameObject rightAnchor;

	private string mPlayerName;

	private string mPlayerId;

	private bool mIsFlawless;

	public void Initialize(int position, DatabasePlayerData player, int count, int width = 600)
	{
		mPlayerName = player.name;
		mPlayerId = player.id;
		mIsFlawless = player.hasFlawlessRun;
		int heroWins = player.heroWins;
		if (player.id == DatabasePlayerData.currentPlayer.id)
		{
			background.alpha = 1f;
			if (position > 2 && position < count - 1 && position < 99)
			{
				GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition = position - 1;
			}
		}
		else
		{
			background.alpha = 0.35f;
		}
		SetSize(width);
		nameCollider.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(nameCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NameClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(nameCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NameClick));
		positionAndName.color = ((!mIsFlawless) ? Colours.greenArena : Colours.goldFlawless);
		positionAndName.text = $"[FFFFFF]{MiscTools.FormatNumberToOrdinalPoint(position)}[-]  {mPlayerName}";
		MiscTools.SetUILabelRescale(positionAndName, 32f, 20f, width - 172);
		float num = positionAndName.relativeSize.x * positionAndName.transform.localScale.x;
		nameCollider.size = nameCollider.size.ReplaceX(num + 10f);
		nameCollider.center = nameCollider.center.ReplaceX(num / 2f);
		winsIcon.gameObject.SetActive(!mIsFlawless);
		flawlessIcon.gameObject.SetActive(mIsFlawless);
		winsLabel.text = MiscTools.FormatBigNumber(heroWins);
		MiscTools.SetUILabelRescale(winsLabel, 30f, 20f, 56);
	}

	public void InitializeYou(bool isFlawless, int winsNumber, int width = 600)
	{
		mPlayerName = null;
		mPlayerId = null;
		mIsFlawless = isFlawless;
		background.alpha = 1f;
		SetSize(width);
		nameCollider.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(nameCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NameClick));
		positionAndName.color = Colours.greenArena;
		positionAndName.text = Localization.Localize("ID_YOURBEST");
		MiscTools.SetUILabelRescale(positionAndName, 32f, 20f, width - 172);
		winsIcon.gameObject.SetActive(!mIsFlawless);
		flawlessIcon.gameObject.SetActive(mIsFlawless);
		winsLabel.text = MiscTools.FormatBigNumber(winsNumber);
		MiscTools.SetUILabelRescale(winsLabel, 30f, 20f, 56);
	}

	private void SetSize(int width)
	{
		background.transform.localScale = background.transform.localScale.ReplaceX(width);
		leftAnchor.transform.localPosition = leftAnchor.transform.localPosition.ReplaceX(-width / 2);
		rightAnchor.transform.localPosition = rightAnchor.transform.localPosition.ReplaceX(width / 2);
	}

	private void NameClick(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayerId))
		{
			TweenColor tweenColor = TweenColor.Begin(positionAndName.gameObject, 0.2f, (!mIsFlawless) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayerName, mPlayerId);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		mPlayerName = null;
		mPlayerId = null;
		UIEventListener uIEventListener = UIEventListener.Get(nameCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NameClick));
	}
}
