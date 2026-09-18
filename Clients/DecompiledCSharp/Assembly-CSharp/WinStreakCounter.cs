using System;
using UnityEngine;

public class WinStreakCounter : Core_BaseScript
{
	[Header("Core")]
	public UILabel counterLabel;

	[Header("Only for DogTag Dialog")]
	public UISprite timerBar;

	public Action winStreakTimer;

	public Action TextChanged;

	private bool mIsStarted;

	private bool mUpperCaseCountdown;

	private int mSeconds;

	private int mStartingTime;

	private int mDeadline;

	public override string ToString()
	{
		return MiscTools.PrintableTime(mSeconds, "ID_READYTIME", string.Empty);
	}

	internal void StartCounter(int seconds)
	{
		mDeadline = Singleton<BeanstalkServerManager>.instance.currentTimestamp + seconds;
		if (!mIsStarted)
		{
			mIsStarted = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.updateCounterForGuiStrings = (Action)Delegate.Combine(instance.updateCounterForGuiStrings, new Action(UpdateCounter));
		}
	}

	private void UpdateCounter()
	{
		if (!mIsStarted)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp > mDeadline)
		{
			StopCounter();
			if (winStreakTimer != null)
			{
				winStreakTimer();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			mSeconds = mDeadline - currentTimestamp;
			counterLabel.text = MiscTools.PrintableTime(mSeconds, "ID_READYTIME", string.Empty);
			if (TextChanged != null)
			{
				TextChanged();
			}
			if (timerBar != null)
			{
				timerBar.fillAmount = Singleton<DogTagManager>.instance.progressToNextDogtag;
			}
		}
	}

	internal void StopCounter()
	{
		mIsStarted = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterForGuiStrings = (Action)Delegate.Remove(instance.updateCounterForGuiStrings, new Action(UpdateCounter));
	}

	internal void StartMessageCenterCounter(int seconds)
	{
		mDeadline = Singleton<BeanstalkServerManager>.instance.currentTimestamp + seconds;
		if (!mIsStarted)
		{
			mIsStarted = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.updateCounterForGuiStrings = (Action)Delegate.Combine(instance.updateCounterForGuiStrings, new Action(UpdateMessageCenterCounter));
		}
	}

	private void UpdateMessageCenterCounter()
	{
		if (!mIsStarted)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp > mDeadline)
		{
			StopMessageCenterCounter();
			counterLabel.text = Localization.Localize("ID_EXPIRED");
			if (TextChanged != null)
			{
				TextChanged();
			}
			if (winStreakTimer != null)
			{
				winStreakTimer();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			mSeconds = mDeadline - currentTimestamp;
			counterLabel.text = string.Format("{0} {1}{2}", Localization.Localize("ID_EXPIRESIN"), Colours.stringBlue, MiscTools.PrintableTimeTwoDigits(mSeconds));
			if (TextChanged != null)
			{
				TextChanged();
			}
		}
	}

	internal void StopMessageCenterCounter()
	{
		mIsStarted = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterForGuiStrings = (Action)Delegate.Remove(instance.updateCounterForGuiStrings, new Action(UpdateMessageCenterCounter));
	}

	internal void StartTimer(int messageTime)
	{
		mStartingTime = messageTime;
		if (!mIsStarted)
		{
			mIsStarted = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.updateCounterByMinute = (Action)Delegate.Combine(instance.updateCounterByMinute, new Action(UpdateTimestampCounter));
		}
		UpdateTimestampCounter();
	}

	private void UpdateTimestampCounter()
	{
		if (mIsStarted && base.gameObject.activeInHierarchy)
		{
			mSeconds = Singleton<BeanstalkServerManager>.instance.currentTimestamp - mStartingTime;
			counterLabel.text = MiscTools.PrintableTimeMessageCenter(mSeconds);
			if (TextChanged != null)
			{
				TextChanged();
			}
		}
	}

	internal void StopTimer()
	{
		mIsStarted = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterByMinute = (Action)Delegate.Remove(instance.updateCounterByMinute, new Action(UpdateTimestampCounter));
	}

	internal void StartChatTimer(int chatTime)
	{
		mStartingTime = chatTime;
		if (!mIsStarted)
		{
			mIsStarted = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.updateCounterByMinute = (Action)Delegate.Combine(instance.updateCounterByMinute, new Action(UpdateChatTimestampCounter));
		}
		UpdateChatTimestampCounter();
	}

	private void UpdateChatTimestampCounter()
	{
		if (mIsStarted && base.gameObject.activeInHierarchy)
		{
			mSeconds = Singleton<BeanstalkServerManager>.instance.currentTimestamp - mStartingTime;
			counterLabel.text = MiscTools.PrintableTimeMessageCenter(mSeconds).ToLower();
			if (TextChanged != null)
			{
				TextChanged();
			}
		}
	}

	internal void StopChatTimer()
	{
		mIsStarted = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterByMinute = (Action)Delegate.Remove(instance.updateCounterByMinute, new Action(UpdateChatTimestampCounter));
	}

	internal void StartCountingTo(int deadline, bool upperCaseCountdown = false)
	{
		mDeadline = deadline;
		mUpperCaseCountdown = upperCaseCountdown;
		if (!mIsStarted)
		{
			mIsStarted = true;
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.updateCounterForGuiStrings = (Action)Delegate.Combine(instance.updateCounterForGuiStrings, new Action(UpdateDeadlineCounter));
		}
		UpdateDeadlineCounter();
	}

	private void UpdateDeadlineCounter()
	{
		if (!mIsStarted)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (currentTimestamp > mDeadline)
		{
			StopCountingTo();
			if (winStreakTimer != null)
			{
				winStreakTimer();
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			mSeconds = mDeadline - currentTimestamp;
			counterLabel.text = ((!mUpperCaseCountdown) ? MiscTools.PrintableTime(mSeconds, "ID_READYTIME", string.Empty) : MiscTools.PrintableTime(mSeconds, "ID_READYTIME", string.Empty).ToUpper());
			if (TextChanged != null)
			{
				TextChanged();
			}
		}
	}

	internal void StopCountingTo()
	{
		mIsStarted = false;
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterForGuiStrings = (Action)Delegate.Remove(instance.updateCounterForGuiStrings, new Action(UpdateDeadlineCounter));
	}
}
