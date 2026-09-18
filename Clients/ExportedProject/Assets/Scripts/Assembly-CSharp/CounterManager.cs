using System;
using System.Collections;
using UnityEngine;

public class CounterManager : Singleton<CounterManager>
{
	public float specialCounterPeriod = 1f;

	public Action updateCounters;

	public Action updateCounterBySecond;

	public Action updateCounterByMinute;

	public Action updateCounterSpecial;

	public Action updateCounterForGuiStrings;

	private bool mEveryMinuteCoroutineIsRunning;

	private bool mEverySecondUpdateRunning;

	private bool mSpecialCoroutineRunnig;

	private bool mGUIStringsCoroutineRunnig;

	protected void Update()
	{
		if (updateCounters != null)
		{
			updateCounters();
		}
		if (updateCounterByMinute != null && !mEveryMinuteCoroutineIsRunning)
		{
			mEveryMinuteCoroutineIsRunning = true;
			StartCoroutine(UpdateCoroutineByMinute());
		}
		if (updateCounterBySecond != null && !mEverySecondUpdateRunning)
		{
			mEverySecondUpdateRunning = true;
			StartCoroutine(UpdateCoroutineBySecond());
		}
		if (updateCounterSpecial != null && !mSpecialCoroutineRunnig)
		{
			mSpecialCoroutineRunnig = true;
			StartCoroutine(UpdateCoroutineSpecial());
		}
		if (updateCounterForGuiStrings != null && !mGUIStringsCoroutineRunnig)
		{
			mGUIStringsCoroutineRunnig = true;
			StartCoroutine(UpdateCoroutineGuiStrings());
		}
	}

	private IEnumerator UpdateCoroutineByMinute()
	{
		bool shouldContinue = true;
		while (shouldContinue)
		{
			if (updateCounterByMinute != null)
			{
				updateCounterByMinute();
				yield return new WaitForSeconds(60f);
			}
			else
			{
				shouldContinue = false;
			}
		}
		mEveryMinuteCoroutineIsRunning = false;
	}

	private IEnumerator UpdateCoroutineBySecond()
	{
		bool shouldContinue = true;
		while (shouldContinue)
		{
			if (updateCounterBySecond != null)
			{
				updateCounterBySecond();
				yield return new WaitForSeconds(1f);
			}
			else
			{
				shouldContinue = false;
			}
		}
		mEverySecondUpdateRunning = false;
	}

	private IEnumerator UpdateCoroutineSpecial()
	{
		bool shouldContinue = true;
		while (shouldContinue)
		{
			if (updateCounterSpecial != null)
			{
				updateCounterSpecial();
				yield return new WaitForSeconds(specialCounterPeriod);
			}
			else
			{
				shouldContinue = false;
			}
		}
		mSpecialCoroutineRunnig = false;
	}

	private IEnumerator UpdateCoroutineGuiStrings()
	{
		while (updateCounterForGuiStrings != null)
		{
			updateCounterForGuiStrings();
			yield return new WaitForSeconds(0.333f);
		}
		mGUIStringsCoroutineRunnig = false;
	}
}
