using System;
using System.Collections.Generic;
using UnityEngine;

public class ArmyElitePerkHint : Core_BaseScript
{
	[SerializeField]
	[Header("Core")]
	private BoxCollider mHintButton;

	[SerializeField]
	private UISprite mHintButtonBackground;

	[SerializeField]
	private UIPanel mHintDialog;

	[SerializeField]
	private BoxCollider mHintDialogCollider;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private UISprite[] mIcons;

	[SerializeField]
	private UILabel[] mLabels;

	[SerializeField]
	[Header("Setting")]
	private Vector3 mBasePosition = new Vector3(0f, 0f, 0f);

	public void InitControls()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OnHintButtonClick;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = OnHintDialogClick;
	}

	public void InitGUIValues()
	{
		InstantHideHint();
	}

	public void DoAfterHide()
	{
		InstantHideHint();
	}

	public void Initialize(LevelBehaviour unit)
	{
		PerkType perkType = unit.perkType;
		HashSet<Type> units = PerkUnitCategories.GetUnits(unit.perkAffects);
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		foreach (Type item in units)
		{
			LevelBehaviour unit2 = LevelManager.instance.GetUnit(item);
			if (unit2 != null)
			{
				list.Add(unit2);
			}
		}
		list.Sort((LevelBehaviour u1, LevelBehaviour u2) => u1.upgradeSlots.unlockLevelIndex.CompareTo(u2.upgradeSlots.unlockLevelIndex));
		float num = 192f + 62f * (float)(list.Count - 1) + 74f;
		mTitle.text = ((perkType != PerkType.Buff) ? Localization.LocalizeFormat("ID_AFFECTEDENEMYUNITS", Colours.stringGreenArena, unit.unitBuffName) : Localization.LocalizeFormat("ID_AFFECTEDOWNUNITS", Colours.stringGreenArena, unit.unitBuffName));
		MiscTools.SetUILabelRescale(mTitle, 30f, 20f);
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			if (mIcons.Length > num2)
			{
				mIcons[num2].gameObject.SetActive(value: true);
				mIcons[num2].spriteName = ((perkType != PerkType.Buff) ? "game-elite-debuff1" : "game-elite-buff1");
			}
			if (mLabels.Length > num2)
			{
				mLabels[num2].gameObject.SetActive(value: true);
				mLabels[num2].text = list[num2].unitName;
			}
		}
		for (int num3 = list.Count; num3 < mIcons.Length; num3++)
		{
			mIcons[num3].gameObject.SetActive(value: false);
		}
		for (int num4 = list.Count; num4 < mLabels.Length; num4++)
		{
			mLabels[num4].gameObject.SetActive(value: false);
		}
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY((0f - num) / 2f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num);
	}

	private void OnHintButtonClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HideHint();
		}
		else
		{
			ShowHint();
		}
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new ElitePerkTutorialMessage());
			ElitesFeatureShownRequest.Send();
		}
	}

	private void OnHintDialogClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HideHint();
	}

	private void ShowHint()
	{
		mHintButtonBackground.spriteName = MiscTools.closeButtonSprite;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
		mHintDialog.alpha1 = 0.005f;
		TweenAlpha.Begin(mHintDialog.gameObject, 0.4f, 1f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(-20f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 0.25f, mBasePosition.AddY(-20f), mBasePosition.AddY(10f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(mHintDialog.gameObject, 0.15f, mBasePosition);
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void HideHint()
	{
		mHintButtonBackground.spriteName = MiscTools.infoButtonSprite;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 0.4f, mBasePosition.AddY(20f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			InstantHideHint();
		};
	}

	private void InstantHideHint()
	{
		mHintButtonBackground.spriteName = MiscTools.infoButtonSprite;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
	}
}
