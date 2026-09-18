using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionDeals : Core_BaseScript
{
	[Header("Background")]
	public UISprite headerBackground;

	public UISprite headerCorner;

	public UISprite background;

	[Header("Deals")]
	public List<IntroductionDealsItem> deals;

	[Header("Parameters")]
	public float dealFadeTime = 0.3f;

	public float backroundFadeTime = 0.35f;

	private RadicalRoutine mRotateCoroutine;

	public void InitEvents()
	{
		foreach (IntroductionDealsItem deal in deals)
		{
			deal.gameObject.SetActive(value: true);
			deal.InitEvents();
		}
	}

	public void InitControls()
	{
		HideBackground();
		foreach (IntroductionDealsItem deal in deals)
		{
			deal.gameObject.SetActive(value: true);
			deal.InitControls();
		}
	}

	public void InitGuiValues()
	{
		foreach (IntroductionDealsItem deal in deals)
		{
			deal.gameObject.SetActive(value: true);
			deal.InitGuiValues();
		}
	}

	public void AnimateShow()
	{
		foreach (IntroductionDealsItem deal in deals)
		{
			StartCoroutine(deal.Hide(0f));
		}
		Show();
	}

	public void DoBeforeHide()
	{
		Hide();
	}

	private void Show()
	{
		mRotateCoroutine = RadicalRoutine.Create(RotateWorker());
		StartCoroutine(RadicalRoutine.Run(mRotateCoroutine.enumerator));
	}

	private void Hide()
	{
		if (mRotateCoroutine != null)
		{
			mRotateCoroutine.Cancel();
		}
		foreach (IntroductionDealsItem deal in deals)
		{
			StartCoroutine(deal.Hide(0f));
		}
		HideBackground();
	}

	private void ShowBackground()
	{
		TweenAlpha.Begin(headerBackground.gameObject, backroundFadeTime, 0.81f);
		TweenAlpha.Begin(headerCorner.gameObject, backroundFadeTime, 0.81f);
		TweenAlpha.Begin(background.gameObject, backroundFadeTime, 0.5f);
	}

	private void HideBackground()
	{
		TweenAlpha.Begin(headerBackground.gameObject, backroundFadeTime, 0f);
		TweenAlpha.Begin(headerCorner.gameObject, backroundFadeTime, 0f);
		TweenAlpha.Begin(background.gameObject, backroundFadeTime, 0f);
	}

	private IEnumerator RotateWorker()
	{
		bool backgroundVisible = false;
		IntroductionDealsItem currentDeal = null;
		while (true)
		{
			if (currentDeal != null && currentDeal.hasMoreLooks && !currentDeal.isLastLook)
			{
				yield return StartCoroutine(currentDeal.Change(dealFadeTime));
			}
			else
			{
				IntroductionDealsItem nextDeal = GetNextDeal(currentDeal);
				if (nextDeal != null && !backgroundVisible)
				{
					backgroundVisible = true;
					ShowBackground();
				}
				if (nextDeal == null && backgroundVisible)
				{
					backgroundVisible = false;
					HideBackground();
				}
				if (currentDeal != nextDeal)
				{
					if (currentDeal != null)
					{
						yield return StartCoroutine(currentDeal.Hide(dealFadeTime));
					}
					if (nextDeal != null)
					{
						yield return StartCoroutine(nextDeal.Show(dealFadeTime));
					}
					currentDeal = nextDeal;
				}
			}
			do
			{
				yield return null;
			}
			while (currentDeal != null && currentDeal.IsShowTime());
		}
	}

	private IntroductionDealsItem GetNextDeal(IntroductionDealsItem currentDeal)
	{
		int num = deals.IndexOf(currentDeal);
		num++;
		for (int i = 0; i < deals.Count; i++)
		{
			IntroductionDealsItem introductionDealsItem = deals[(num + i) % deals.Count];
			if (introductionDealsItem.IsAvailable())
			{
				return introductionDealsItem;
			}
		}
		return null;
	}
}
