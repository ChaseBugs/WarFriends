using System.Collections.Generic;
using UnityEngine;

public class CardsGuiElementNew : GuiElement
{
	public CardsGuiCloseButton closeButton;

	public static Vector3 firstCardPosition;

	private readonly List<GameGuiCard> cards = new List<GameGuiCard>();

	private readonly Queue<Card> notShowedCards = new Queue<Card>();

	public GameGuiCard cardPrefab;

	private float mDur = 0.05f;

	private float mTutorialDur = 0.1f;

	private bool mCardSelection;

	private bool mCardAnimation;

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		Singleton<GameController>.instance.GameEnded += delegate
		{
			foreach (GameGuiCard card in cards)
			{
				if (card.card != null)
				{
					card.card = null;
				}
			}
		};
		CardManager.instance.OnCardGainedInGame += delegate(Card card)
		{
			notShowedCards.Enqueue(card);
		};
		firstCardPosition = base.transform.position;
	}

	private void PositionRotationForCard(int i, out Vector3 pos, out Quaternion rotation, out Vector3 scale, int totalCount)
	{
		float num = 22f;
		float num2 = num * ((float)totalCount * 0.5f) - num * 0.5f;
		float num3 = 10f;
		Vector3 vector = new Vector3((0f - (float)totalCount * 0.5f) * num3, 0f, 0f);
		rotation = Quaternion.Euler(0f, 0f, num2 - (float)i * num);
		pos = vector + new Vector3((float)i * num3, 0f, 0f) + new Vector3(0f, 10f, i * 4);
		scale = Vector3.one;
	}

	private void PositionRotationForCardSelect(int index, int count, out Vector3 pos, out Quaternion rotation, out Vector3 scale)
	{
		pos = new Vector3(((float)index - 0.5f * (float)(count - 1)) * 300f, (float)UIRoot.list[0].activeHeight / 2f - 400f, index * 4);
		rotation = Quaternion.identity;
		scale = 1.2f * Vector3.one;
	}

	private void PrepareCardPositions(GameGuiCard cardP, int counter, Card card, bool addDepth)
	{
		cardP.transform.parent = base.transform;
		cardP.InitFromCard(this, card, (!addDepth) ? counter : (counter + 1));
	}

	private void RepositionCards()
	{
		for (int i = 0; i < cards.Count; i++)
		{
			GameGuiCard gameGuiCard = cards[i];
			Vector3 pos;
			Quaternion rotation;
			Vector3 scale;
			if (mCardSelection)
			{
				PositionRotationForCardSelect(i, cards.Count, out pos, out rotation, out scale);
			}
			else
			{
				PositionRotationForCard(i, out pos, out rotation, out scale, cards.Count);
			}
			gameGuiCard.transform.localPosition = pos;
			gameGuiCard.transform.localRotation = rotation;
			gameGuiCard.transform.localScale = scale;
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				TutorialAnimationCard(gameGuiCard, i, pos, rotation, scale);
			}
		}
	}

	private void InstanceOnGameStarted()
	{
		mCardSelection = false;
		mCardAnimation = false;
		notShowedCards.Clear();
		cards.Clear();
		Singleton<GuiManager>.instance.objectPool.FreeObjectsWithPrefab(cardPrefab);
		if (CardManager.instance.canUseCards)
		{
			int num = 0;
			foreach (Card item in CardManager.instance.cardsForGame)
			{
				GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.objectPool.Instantiate(cardPrefab);
				if (gameGuiCard == null)
				{
					notShowedCards.Enqueue(item);
					continue;
				}
				PrepareCardPositions(gameGuiCard, num, item, addDepth: false);
				num++;
				cards.Add(gameGuiCard);
				UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(includeInactive: true);
				UIPanel[] array = componentsInChildren;
				foreach (UIPanel uIPanel in array)
				{
					TweenAlpha.Begin(uIPanel.gameObject, 0f, 0.01f);
				}
			}
		}
		RepositionCards();
		closeButton.transform.localPosition = new Vector3(0f, -113f, 0f);
		closeButton.transform.localRotation = Quaternion.identity;
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
	}

	protected override void Update()
	{
		base.Update();
		while (notShowedCards.Count > 0 && !mCardAnimation)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.objectPool.Instantiate(cardPrefab);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = cards.Count;
			PrepareCardPositions(gameGuiCard, count, notShowedCards.Dequeue(), addDepth: true);
			cards.Add(gameGuiCard);
			if (CardManager.instance.Progress != 0f)
			{
				gameGuiCard.PlayProgress();
			}
			RepositionCards();
		}
	}

	public void OnCardClick(GameGuiCard cardGui)
	{
		if (!mCardSelection)
		{
			ShowCardAnimation();
		}
		else if (CardManager.instance.Progress == 0f)
		{
			cards.Remove(cardGui);
			cardGui.UseCard();
			for (int i = 0; i < cards.Count; i++)
			{
				cards[i].PlayProgress();
			}
			HideCardsAnimation();
		}
	}

	public void OnCloseButtonClick()
	{
		if (!mCardAnimation && mCardSelection)
		{
			HideCardsAnimation();
		}
	}

	private void TutorialAnimationCard(GameGuiCard card, int counter, Vector3 position, Quaternion rotation, Vector3 scale)
	{
		card.Disable();
		float del = (float)(counter * 2) * mTutorialDur;
		float duration = 0.5f + del;
		Vector3 startPosition = new Vector3(-370f + (float)counter * 400f, (float)UIRoot.list[0].activeHeight / 2f - 150f, 0f);
		card.SetUpWhite();
		TweenRotation tweenRotation = TweenRotation.Begin(card.gameObject, 0.05f, Quaternion.identity);
		tweenRotation.delay = 0f;
		TweenPosition tweenPosition = TweenPosition.Begin(card.gameObject, 0.05f, startPosition);
		tweenPosition.delay = 0f;
		TweenScale tweenScale = TweenScale.Begin(card.gameObject, duration, new Vector3(0.005f, 0.005f, 1f), new Vector3(0.005f, 0.005f, 1f));
		tweenScale.delay = 0f;
		tweenScale.onFinished = delegate
		{
			Vector3 pos = startPosition - new Vector3(30f * (float)(2 - counter), 0f, 0f);
			float duration2 = mTutorialDur * 8f - del;
			TweenPosition tweenPosition2 = TweenPosition.Begin(card.gameObject, duration2, pos);
			tweenPosition2.delay = 0f;
			TweenScale tweenScale2 = TweenScale.Begin(card.gameObject, mTutorialDur * 4f, new Vector3(2f, 2f, 1f));
			tweenScale2.delay = 0f;
			tweenScale2.method = UITweener.Method.Linear;
			tweenScale2.onFinished = delegate
			{
				TweenScale tweenScale3 = TweenScale.Begin(card.gameObject, mTutorialDur * 2f, new Vector3(1.5f, 1.5f, 1f));
				tweenScale3.delay = 0f;
				tweenScale3.method = UITweener.Method.EaseOut;
				tweenScale3.onFinished = delegate
				{
					float num = 0.7f - del;
					TweenPosition tweenPosition3 = TweenPosition.Begin(card.gameObject, mTutorialDur * 6f, position);
					tweenPosition3.delay = num + mTutorialDur * 3f * (float)(2 - counter);
					tweenPosition3.onFinished = delegate
					{
						if (counter > 0)
						{
							card.SetUpWhite();
						}
						card.Enable();
					};
					TweenRotation tweenRotation2 = TweenRotation.Begin(card.gameObject, mTutorialDur * 2f, rotation);
					tweenRotation2.delay = num + mTutorialDur * 2f * (float)counter;
					TweenScale tweenScale4 = TweenScale.Begin(card.gameObject, mTutorialDur * (float)((counter != 0) ? 12 : 4), scale);
					tweenScale4.method = UITweener.Method.EaseInOut;
					tweenScale4.delay = num + mTutorialDur * 2f;
				};
			};
		};
	}

	private void ShowCardAnimation()
	{
		bool isTutorial = Singleton<GameController>.instance.isTutorial;
		float duration = 5f * mDur;
		mCardAnimation = true;
		foreach (GameGuiCard card in cards)
		{
			card.Disable();
			card.GetComponent<Collider>().enabled = false;
		}
		mCardSelection = true;
		mCardAnimation = isTutorial;
		TweenPosition tweenPosition = TweenPosition.Begin(closeButton.gameObject, duration, new Vector3(0f, 155f, 0f));
		tweenPosition.delay = 0f;
		TweenRotation tweenRotation = TweenRotation.Begin(closeButton.gameObject, duration, Quaternion.AngleAxis(179.9f, Vector3.forward));
		tweenRotation.delay = 0f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 0; i < cards.Count; i++)
		{
			GameGuiCard gameGuiCard = cards[i];
			float delay = (float)i * mDur;
			duration = 3f * mDur;
			PositionRotationForCard(i, out var pos, out var rotation, out var scale, cards.Count);
			PositionRotationForCardSelect(i, cards.Count, out var pos2, out var rotation2, out var scale2);
			gameGuiCard.transform.localPosition = pos;
			gameGuiCard.transform.localRotation = rotation;
			gameGuiCard.transform.localScale = scale;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, pos2);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, rotation2);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, scale2);
			tweenScale.delay = delay;
			if (i != cards.Count - 1)
			{
				continue;
			}
			tweenScale.onFinished = delegate
			{
				foreach (GameGuiCard card2 in cards)
				{
					card2.Enable();
					card2.GetComponent<Collider>().enabled = true;
				}
				mCardAnimation = false;
			};
		}
	}

	private void HideCardsAnimation()
	{
		float duration = 5f * mDur;
		mCardSelection = false;
		mCardAnimation = true;
		TweenPosition tweenPosition = TweenPosition.Begin(closeButton.gameObject, duration, new Vector3(0f, -113f, 0f));
		tweenPosition.delay = 0f;
		TweenRotation tweenRotation = TweenRotation.Begin(closeButton.gameObject, duration, Quaternion.identity);
		tweenRotation.delay = 0f;
		tweenRotation.onFinished = delegate
		{
			if (cards.Count == 0)
			{
				mCardAnimation = false;
			}
		};
		for (int num = 0; num < cards.Count; num++)
		{
			GameGuiCard gameGuiCard = cards[num];
			float delay = (float)num * mDur;
			duration = 5f * mDur;
			gameGuiCard.Disable();
			gameGuiCard.GetComponent<Collider>().enabled = false;
			Vector3 localPosition = gameGuiCard.transform.localPosition;
			Quaternion localRotation = gameGuiCard.transform.localRotation;
			Vector3 localScale = gameGuiCard.transform.localScale;
			PositionRotationForCard(num, out var pos, out var rotation, out var scale, cards.Count);
			gameGuiCard.transform.localPosition = localPosition;
			gameGuiCard.transform.localRotation = localRotation;
			gameGuiCard.transform.localScale = localScale;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, pos);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, rotation);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, scale);
			tweenScale.delay = delay;
			if (num != cards.Count - 1)
			{
				continue;
			}
			tweenScale.onFinished = delegate
			{
				foreach (GameGuiCard card in cards)
				{
					card.Enable();
					card.GetComponent<Collider>().enabled = true;
				}
				mCardAnimation = false;
			};
		}
	}

	public Vector3 GetFirstCardPosition()
	{
		if (cards.Count > 0)
		{
			return cards[0].transform.position;
		}
		return base.transform.position;
	}
}
