using UnityEngine;

public class CraftCardOverlay : Core_BaseScript
{
	[Header("Core")]
	public UIPanel panel;

	public UILabel title;

	public GameObject startPosition;

	public GameObject endPosition;

	public CardRecord cardRecordPrefab;

	[Header("Continue Button")]
	public GameObject continueButton;

	public AnimationCurve buttonAnimatinCurve;

	private CardRecord mCraftedWarcard;

	public void InitControls()
	{
		UIEventListener.Get(continueButton.gameObject).onClick = HidingAnimation;
	}

	private void HidingAnimation(GameObject go)
	{
		TweenAlpha.Begin(panel.gameObject, 0.2f, 0f).onFinished = delegate
		{
			PrepareOverlay();
		};
		if (mCraftedWarcard != null)
		{
			TweenAlpha.Begin(mCraftedWarcard.gameObject, 0.2f, 0f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.ClaimingAnimationFinished();
	}

	public void PrepareOverlay()
	{
		base.gameObject.SetActive(value: true);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		panel.alpha1 = 0f;
		base.gameObject.SetActive(value: false);
		if (mCraftedWarcard != null)
		{
			mCraftedWarcard.DestroyPooled();
			mCraftedWarcard = null;
		}
	}

	public void AnimateWarcard(Card craftedCard)
	{
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(value: true);
		panel.alpha1 = 0f;
		panel.isFreezed = false;
		float initDelay = 0.05f;
		TweenAlpha.Begin(panel.gameObject, 0.2f, 0f, 1f).onFinished = delegate
		{
			Debug.Log("Creating warcard " + craftedCard.cardName);
			mCraftedWarcard = (CardRecord)Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(cardRecordPrefab, endPosition, "Crafted warcard " + craftedCard.cardName);
			if (mCraftedWarcard != null)
			{
				mCraftedWarcard.Initialize(craftedCard);
				mCraftedWarcard.PrepareBuyAnimation();
				mCraftedWarcard.boxCollider.enabled = false;
				mCraftedWarcard.transform.position = startPosition.transform.position;
				float duration = 0.5f;
				TweenAlpha.Begin(mCraftedWarcard.backOfCard.gameObject, 0.1f, 0f, 1f).delay = initDelay;
				TweenScale.Begin(mCraftedWarcard.backOfCard.gameObject, duration, mCraftedWarcard.backOfCard.cachedTransform.localScale.MultiplyXY(2f)).delay = initDelay + 0.05f;
				TweenPosition tweenPosition2 = TweenPosition.Begin(mCraftedWarcard.gameObject, duration, Vector3.zero);
				tweenPosition2.delay = initDelay + 0.05f;
				tweenPosition2.onFinished = delegate
				{
					mCraftedWarcard.FlipBuyAnimation(0);
				};
			}
		};
		float delay = initDelay + 0.2f;
		continueButton.transform.localPosition = new Vector3(0f, -100f, 0f);
		TweenPosition tweenPosition = TweenPosition.Begin(continueButton.gameObject, 0.6f, new Vector3(0f, 160f, 0f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = buttonAnimatinCurve;
	}
}
