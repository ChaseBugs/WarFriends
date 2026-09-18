using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainedCardsAnimation : Core_BaseScript
{
	[Header("Header")]
	public UILabel header;

	[Header("Animation")]
	public GameObject cardCenter;

	public CardRecord cardRecordPrefab;

	private ObjectPool mPool;

	private List<CardRecord> mCards;

	private int mCount;

	public void InitControls()
	{
		header.alpha = 0f;
		mPool = Singleton<GuiManager>.instance.objectPool;
		mCards = new List<CardRecord>();
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += delegate(DatabaseAction action)
		{
			if (GuiScreenSingle<EndScreen>.instance.isShowed && action == DatabaseAction.AddVideoReward)
			{
				WaitingDialog.Hide();
			}
		};
	}

	public void InitGUIValues()
	{
		mCards.Clear();
		foreach (Card obtainedCard in CardManager.instance.obtainedCards)
		{
			CardRecord cardRecord = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, cardCenter, $"Player Card {5 - obtainedCard.rarityNumber} {obtainedCard.cardName} {mCount++}");
			if (cardRecord != null)
			{
				cardRecord.Initialize(obtainedCard);
				cardRecord.SetInvisible();
				mCards.Add(cardRecord);
			}
		}
	}

	public IEnumerator PlayAnimation()
	{
		base.gameObject.SetActive(value: true);
		yield return StartCoroutine(LootboxesAnimationCoroutine());
		GuiScreenSingle<EndScreen>.instance.isEndScreenLootboxAnimations = false;
		if (mCards.Count == 0)
		{
			base.gameObject.SetActive(value: false);
			yield break;
		}
		Vector3 headerPosition = header.transform.localPosition;
		TweenAlpha.Begin(header.gameObject, 0.4f, 0f, 1f);
		TweenPosition tw = TweenPosition.Begin(header.gameObject, 0.4f, headerPosition, headerPosition + new Vector3(0f, 50f, 0f));
		tw.method = UITweener.Method.Linear;
		tw.onFinished = delegate
		{
			TweenPosition tweenPosition = TweenPosition.Begin(header.gameObject, 0.4f, headerPosition);
			tweenPosition.method = UITweener.Method.Linear;
			TweenAlpha.Begin(header.gameObject, 0.2f, 1f, 1f).onFinished = delegate
			{
			};
		};
		yield return new WaitForSeconds(0.6f);
		yield return StartCoroutine(CardsAnimationCoroutine());
	}

	private IEnumerator CardsAnimationCoroutine()
	{
		foreach (CardRecord cardObject in mCards)
		{
			cardObject.EndScreenAnimation(Singleton<GameController>.instance.isTutorial);
			float time = Time.time + 1.4f + ((!Singleton<GameController>.instance.isTutorial) ? 0f : 2f);
			bool clicked = false;
			while (Time.time < time)
			{
				if (Input.GetMouseButtonDown(0))
				{
					clicked = true;
				}
				yield return null;
				if (clicked && cardObject.cardFlipped)
				{
					cardObject.UnhookAndStopAllTweens();
					cardObject.HideCardInEndScreen();
					clicked = false;
					break;
				}
			}
		}
		foreach (CardRecord cardObject2 in mCards)
		{
			while (cardObject2.isAnimatingCard)
			{
				yield return null;
			}
		}
		TweenAlpha.Begin(header.gameObject, 0.2f, 0f);
		yield return new WaitForSeconds(0.1f);
		FinishTweens();
	}

	private void FinishTweens()
	{
		base.gameObject.SetActive(value: false);
		foreach (CardRecord mCard in mCards)
		{
			mCard.DestroyPooled();
		}
		mCards.Clear();
	}

	private IEnumerator LootboxesAnimationCoroutine()
	{
		Debug.Log("Start of lootbox coroutine");
		if (Singleton<ServerResultsCache>.instance.lastGameReward == null)
		{
			Debug.LogError("End of lootbox coroutine - no rewards for game from server!");
			yield break;
		}
		List<LootboxContent> lootboxes = Singleton<ServerResultsCache>.instance.lastGameReward.lootboxesReward;
		if (lootboxes == null || lootboxes.Count == 0)
		{
			Debug.Log("End of lootbox coroutine - empty lootboxes in rewards");
			yield break;
		}
		GuiElementSingle<LootBoxDialog>.instance.ShowDialogMoreBoxes(lootboxes);
		int deviceTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		yield return new WaitForSeconds(0.1f);
		while (GuiElementSingle<LootBoxDialog>.instance.gameObject.activeSelf)
		{
			yield return null;
		}
		if (!GuiScreenSingle<EndScreen>.instance.shouldGetLootboxForAd)
		{
			yield break;
		}
		yield return new WaitForSeconds(0.6f);
		if (Singleton<EventTrackingManager>.instance.isAdVideoPlaying || deviceTime + 15 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			Debug.Log("User was watching ad - waiting for server reward");
		}
		else
		{
			Debug.Log("User was watching ad - advertisement did not started");
			float addTimeOut = 0f;
			WaitingDialog.ShowDialog("ID_WAITINGFORADVERTISEMENT");
			while (!Singleton<EventTrackingManager>.instance.isAdVideoPlaying && addTimeOut < 30f)
			{
				addTimeOut += Time.deltaTime;
				yield return null;
			}
			while (!GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
			{
				yield return null;
			}
			if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
			{
				WaitingDialog.Hide();
			}
			if (addTimeOut >= 30f)
			{
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ADVERTISEMENTVIDEODIDNOTSTART"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, null, string.Empty);
				yield break;
			}
		}
		while (Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			yield return null;
		}
		while (GuiElementSingle<WaitingDialog>.instance.gameObject.activeSelf)
		{
			yield return null;
		}
		WaitingDialog.ShowDialog("ID_WAITINGFORLOOTBOX");
		yield return new WaitForSeconds(0.1f);
		float serverTimeOut = 0f;
		while (GuiElementSingle<WaitingDialog>.instance.gameObject.activeSelf && serverTimeOut < 30f)
		{
			serverTimeOut += Time.deltaTime;
			if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed && GuiScreenSingle<EndScreen>.instance.videoRewardLootbox != null && GuiScreenSingle<EndScreen>.instance.videoRewardLootbox.Count > 0)
			{
				Debug.Log("User was watching add - waiting for server reward - reward came");
				WaitingDialog.Hide();
			}
			yield return null;
		}
		if (GuiScreenSingle<EndScreen>.instance.videoRewardLootbox != null && GuiScreenSingle<EndScreen>.instance.videoRewardLootbox.Count > 0)
		{
			Debug.Log("User was watching add - showing reward");
			GuiElementSingle<LootBoxDialog>.instance.ShowDialogMoreBoxes(GuiScreenSingle<EndScreen>.instance.videoRewardLootbox, showVideoButton: false);
			yield return new WaitForSeconds(0.1f);
		}
		else if (serverTimeOut > 30f)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_REWARDNOTLOADED"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, null, string.Empty);
			yield break;
		}
		if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
		{
			WaitingDialog.Hide();
		}
		while (GuiElementSingle<WaitingDialog>.instance.gameObject.activeSelf || GuiElementSingle<LootBoxDialog>.instance.gameObject.activeSelf)
		{
			yield return null;
		}
	}
}
