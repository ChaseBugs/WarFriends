using System;
using UnityEngine;

public class GameModesContent : Core_BaseScript
{
	[Header("1 Button")]
	public BoxCollider openButtonCollider;

	public GameObject openButtonNotification;

	public UILabel openButtonNotificationLabel;

	[Header("Opened")]
	public GameObject gameModeOpenedPart;

	public UISprite gameModeOpenedBackground;

	[Header("-Close Button")]
	public BoxCollider closeButtonCollider;

	public GameObject closeButtonIconParent;

	[Header("-Challenge Friend Button")]
	public BoxCollider challengeYourFriendCollider;

	[Header("-Warpath Button")]
	public WarpathHeroicButton warpathButton;

	[Header("-Arena Button")]
	public BigArenaButton arenaButton;

	private bool mAnimating;

	public bool shownModes => gameModeOpenedPart.activeSelf;

	public bool isAnimating => mAnimating;

	public void InitControls()
	{
		float val = UIRoot.list[0].activeWidth - 120f + 6f + 18f;
		gameModeOpenedBackground.transform.localScale = gameModeOpenedBackground.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(openButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OpenModeSelection));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButtonCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseModeSelection));
		UIEventListener uIEventListener3 = UIEventListener.Get(challengeYourFriendCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ChallengeYourFriendClick));
		warpathButton.InitControls();
		arenaButton.InitControls();
	}

	private void OpenModeSelection(GameObject go)
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.mapSelection.isOpened)
		{
			if (GuiScreenSingle<BattlePreparationScreen>.instance.mapSelection.isAnimating)
			{
				return;
			}
			GuiScreenSingle<BattlePreparationScreen>.instance.mapSelection.AnimateHide();
		}
		mAnimating = true;
		SetButtonColliders();
		gameModeOpenedPart.SetActive(value: true);
		arenaButton.ShowArenaButton();
		UIPanel[] componentsInChildren = gameModeOpenedPart.GetComponentsInChildren<UIPanel>(includeInactive: true);
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!componentsInChildren[i].gameObject.activeInHierarchy)
			{
				continue;
			}
			componentsInChildren[i].alpha1 = 0f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 0.4f, 1f);
			if (flag)
			{
				tweenAlpha.onFinished = null;
				continue;
			}
			tweenAlpha.onFinished = delegate
			{
				mAnimating = false;
				SetButtonColliders();
				openButtonNotification.SetActive(value: false);
			};
			flag = true;
		}
		TweenRotationSpecial component = closeButtonIconParent.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		closeButtonIconParent.transform.localRotation = default(Quaternion);
	}

	public void CloseModeSelection(GameObject go)
	{
		mAnimating = true;
		SetButtonColliders();
		UIPanel[] componentsInChildren = gameModeOpenedPart.GetComponentsInChildren<UIPanel>(includeInactive: true);
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!componentsInChildren[i].gameObject.activeInHierarchy)
			{
				continue;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 0.4f, 0f);
			if (flag)
			{
				tweenAlpha.onFinished = null;
				continue;
			}
			tweenAlpha.onFinished = delegate
			{
				mAnimating = false;
				SetButtonColliders();
				gameModeOpenedPart.SetActive(value: false);
				InitializeNotification();
			};
			flag = true;
		}
		TweenRotationSpecial.Begin(closeButtonIconParent, 0.3f, Vector3.forward, 0f, 360f);
	}

	private void ChallengeYourFriendClick(GameObject go)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(FriendInvited, 0f);
	}

	private void FriendInvited(DatabasePlayer player, bool selectedAnybody)
	{
		if (selectedAnybody)
		{
			Singleton<GameController>.instance.SwitchToDeathMatch();
			Singleton<GameController>.instance.StartMultiplayerGame(player);
		}
	}

	private void SetButtonColliders()
	{
		if (mAnimating)
		{
			challengeYourFriendCollider.enabled = false;
			warpathButton.warpathCollider.enabled = false;
			arenaButton.arenaCollider.enabled = false;
		}
		else
		{
			challengeYourFriendCollider.enabled = true;
			warpathButton.warpathCollider.enabled = warpathButton.isColliderEnabled;
			arenaButton.arenaCollider.enabled = LevelManager.instance.showWarArenaPromoLocked || !LevelManager.instance.isWarArenaLocked;
		}
	}

	public void InitGuiValues(bool showGameModes)
	{
		if (showGameModes)
		{
			InstantShow();
		}
		else
		{
			InstantHide();
		}
		InitializeNotification();
		warpathButton.InitGuiValues();
		arenaButton.InitGuiValues();
	}

	public void DoAfterHide()
	{
		arenaButton.DoAfterHide();
	}

	private void InstantHide()
	{
		TweenRotationSpecial component = closeButtonIconParent.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		closeButtonIconParent.transform.localRotation = default(Quaternion);
		UIPanel[] componentsInChildren = gameModeOpenedPart.GetComponentsInChildren<UIPanel>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			TweenAlpha component2 = componentsInChildren[i].gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
		}
		gameModeOpenedPart.SetActive(value: false);
		mAnimating = false;
		SetButtonColliders();
	}

	private void InstantShow()
	{
		gameModeOpenedPart.SetActive(value: true);
		mAnimating = false;
		SetButtonColliders();
		arenaButton.ShowArenaButton();
		TweenRotationSpecial component = closeButtonIconParent.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		closeButtonIconParent.transform.localRotation = default(Quaternion);
	}

	private void InitializeNotification()
	{
		int num = (warpathButton.showNotification ? 1 : 0);
		openButtonNotification.SetActive(num > 0);
		openButtonNotificationLabel.text = MiscTools.FormatBigNumber(num);
	}
}
