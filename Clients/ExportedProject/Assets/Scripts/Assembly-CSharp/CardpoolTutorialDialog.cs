using System;
using UnityEngine;

public class CardpoolTutorialDialog : GuiElementSingle<CardpoolTutorialDialog>, IGuiDialog
{
	[Header("Right")]
	public UITable wholeTextTable;

	public UITable specialLineTable;

	public UILabel[] labels;

	public GameObject[] hideObjects;

	[Header("Left")]
	public CardRecord cardRecordPrefab;

	public GameObject parentForInstantiate;

	public UISprite[] arrows;

	public CardpoolDialogCardRecord[] bottomContainers;

	[Header("Bottom")]
	public GameObject continueButton;

	private CardRecord mInstantiatedCardrecord;

	private int mAnimatingObject = -1;

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(continueButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ContinueClick));
		UITable uITable = specialLineTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(OnLineReposition));
		if (Localization.instance.currentLanguage == "de" || Localization.instance.currentLanguage == "pt")
		{
			for (int i = 0; i < labels.Length; i++)
			{
				labels[i].transform.localScale = new Vector3(38f, 38f, 1f);
			}
		}
		if (Localization.instance.currentLanguage == "it")
		{
			for (int j = 0; j < hideObjects.Length; j++)
			{
				hideObjects[j].SetActive(value: false);
			}
		}
	}

	private void ContinueClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void OnLineReposition()
	{
		wholeTextTable.repositionNow = true;
	}

	public override void InitGUIValues()
	{
		specialLineTable.repositionNow = true;
		mInstantiatedCardrecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(cardRecordPrefab, parentForInstantiate, "Mine Buddy Warcard") as CardRecord;
		if (mInstantiatedCardrecord != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			mInstantiatedCardrecord.Initialize(CardManager.instance.buddyCard, CardRecord.Behaviour.CountDownBuddy);
			mInstantiatedCardrecord.behaviour = CardRecord.Behaviour.Other;
			mInstantiatedCardrecord.countdownPart.SetActive(value: false);
		}
		mAnimatingObject = -1;
		for (int i = 0; i < arrows.Length; i++)
		{
			TweenAlpha component = arrows[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			arrows[i].alpha = 1f;
		}
		bottomContainers[0].InitializeEmpty();
		bottomContainers[0].boxCollider.enabled = false;
		bottomContainers[0].closeIcon.gameObject.SetActive(value: false);
		bottomContainers[1].InitializeCard(CardManager.instance.GetCardInstance("IMMORTAL"));
		bottomContainers[1].boxCollider.enabled = false;
		bottomContainers[1].closeIcon.gameObject.SetActive(value: false);
		bottomContainers[2].InitializeEmpty();
		bottomContainers[2].boxCollider.enabled = false;
		bottomContainers[2].closeIcon.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.CardpoolShown();
	}

	protected override void Update()
	{
		base.Update();
		if (!base.isFullyShowed)
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 7f) % 5;
		if (num != mAnimatingObject)
		{
			mAnimatingObject = num;
			if (mAnimatingObject > -1 && mAnimatingObject < arrows.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(arrows[mAnimatingObject].gameObject, 0.2f, 1f, 0.5f);
				tweenAlpha.style = UITweener.Style.PingPong;
				tweenAlpha.NumOfRepetitions = 2;
			}
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mInstantiatedCardrecord.DestroyPooled();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		ContinueClick(continueButton.gameObject);
	}
}
