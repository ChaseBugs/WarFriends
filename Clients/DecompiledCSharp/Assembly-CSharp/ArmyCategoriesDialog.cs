using System;
using System.Collections.Generic;
using UnityEngine;

public class ArmyCategoriesDialog : GuiElementSingle<ArmyCategoriesDialog>, IGuiDialog
{
	[Header("Core")]
	public GameObject dialogCenter;

	public UISprite background;

	public GameObject closeButton;

	public GameObject bottomPart;

	public GameObject bottomButton;

	[Header("Icons")]
	public UISprite defenderIcon;

	public UISprite rusherIcon;

	public UISprite shooterIcon;

	public UISprite explosiveIcon;

	[Header("Setting")]
	public float fadeAnimationDuration = 0.4f;

	private bool mReminderType;

	private float mTime;

	private List<string> mDefendersSprite = new List<string>();

	private List<string> mRushersSprite = new List<string>();

	private List<string> mShootersSprite = new List<string>();

	private List<string> mExplosiveSprite = new List<string>();

	private int mType;

	private int mDefendersIndex;

	private int mRushersIndex;

	private int mShootersIndex;

	private int mExplosiveIndex;

	public void ShowDialog(bool reminderType = false)
	{
		mReminderType = reminderType;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(bottomButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				mDefendersSprite.Add(behaviour.upgradeSlots.iconName);
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				mRushersSprite.Add(behaviour.upgradeSlots.iconName);
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				mShootersSprite.Add(behaviour.upgradeSlots.iconName);
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				mExplosiveSprite.Add(behaviour.upgradeSlots.iconName);
				break;
			}
		}
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		dialogCenter.transform.localPosition = new Vector3(0f, (!mReminderType) ? (-126f) : 0f, 0f);
		background.transform.localScale = new Vector3(background.transform.localScale.x, (!mReminderType) ? 1038f : 1240f, 1f);
		closeButton.SetActive(!mReminderType);
		bottomPart.SetActive(mReminderType);
		if (mReminderType)
		{
			UIEventListener uIEventListener = UIEventListener.Get(overlayBackground);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		}
		else
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(overlayBackground);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
			UIEventListener uIEventListener3 = UIEventListener.Get(overlayBackground);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		}
		mTime = 0f;
		TweenAlpha.Begin(defenderIcon.gameObject, 0f, 1f).onFinished = null;
		TweenAlpha.Begin(rusherIcon.gameObject, 0f, 1f).onFinished = null;
		TweenAlpha.Begin(shooterIcon.gameObject, 0f, 1f).onFinished = null;
		TweenAlpha.Begin(explosiveIcon.gameObject, 0f, 1f).onFinished = null;
	}

	protected override void Update()
	{
		base.Update();
		mTime += Time.deltaTime;
		if (mTime > 1f)
		{
			mTime = 0f;
			ChangeIcon();
		}
	}

	private void ChangeIcon()
	{
		switch (mType)
		{
		case 0:
			AnimateChange(defenderIcon, (mDefendersSprite.Count <= mDefendersIndex) ? string.Empty : mDefendersSprite[mDefendersIndex]);
			if (++mDefendersIndex >= mDefendersSprite.Count)
			{
				mDefendersIndex = 0;
			}
			break;
		case 1:
			AnimateChange(rusherIcon, (mRushersSprite.Count <= mRushersIndex) ? string.Empty : mRushersSprite[mRushersIndex]);
			if (++mRushersIndex >= mRushersSprite.Count)
			{
				mRushersIndex = 0;
			}
			break;
		case 2:
			AnimateChange(shooterIcon, (mShootersSprite.Count <= mShootersIndex) ? string.Empty : mShootersSprite[mShootersIndex]);
			if (++mShootersIndex >= mShootersSprite.Count)
			{
				mShootersIndex = 0;
			}
			break;
		case 3:
			AnimateChange(explosiveIcon, (mExplosiveSprite.Count <= mExplosiveIndex) ? string.Empty : mExplosiveSprite[mExplosiveIndex]);
			if (++mExplosiveIndex >= mExplosiveSprite.Count)
			{
				mExplosiveIndex = 0;
			}
			break;
		}
		if (++mType > 3)
		{
			mType = 0;
		}
	}

	private void AnimateChange(UISprite spriteObject, string spriteName)
	{
		if (!string.IsNullOrEmpty(spriteName) && !(spriteObject.spriteName == spriteName))
		{
			TweenAlpha.Begin(spriteObject.gameObject, fadeAnimationDuration, 0f).onFinished = delegate
			{
				spriteObject.spriteName = spriteName;
				spriteObject.MakePixelPerfect();
				TweenAlpha.Begin(spriteObject.gameObject, fadeAnimationDuration, 1f).onFinished = null;
			};
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton.gameObject);
	}
}
