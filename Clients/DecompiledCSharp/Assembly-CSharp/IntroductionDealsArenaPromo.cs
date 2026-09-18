using System;
using System.Collections;
using UnityEngine;

public class IntroductionDealsArenaPromo : IntroductionDealsItem
{
	[Header("Arena promo")]
	public Collider buttonCollider;

	public UISprite unitIcon;

	public UILabel timeLabel;

	public GameObject leftWing;

	public GameObject rightWing;

	private bool mIsAvailable;

	private bool mIsRunning;

	private RadicalRoutine mTimeWorker;

	public override void InitEvents()
	{
		base.InitEvents();
		buttonCollider.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(buttonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnButtonClick));
		WarArena.instance.WarArenaDataChanged += OnWarArenaDataChanged;
	}

	private void OnButtonClick(GameObject go)
	{
		GuiScreenSingle<ArenaScreen>.instance.ShowWarArena((WarArena.instance.isArenaTicketBought && WarArena.instance.isOpened) ? ArenaScreen.ArenaScreenMode.MainArena : ArenaScreen.ArenaScreenMode.EnterArena);
		SetShowTimeEnd(0.5f);
	}

	private void OnWarArenaDataChanged()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			UpdateAvailable();
		}
	}

	public override void InitGuiValues()
	{
		base.InitGuiValues();
		UpdateAvailable();
		LevelBehaviour levelBehaviour = ((WarArena.instance.warArenaConfig != null) ? WarArena.instance.warArenaConfig.doubleDropUnit : null);
		bool flag = levelBehaviour != null;
		unitIcon.gameObject.SetActive(flag);
		if (flag)
		{
			unitIcon.spriteName = levelBehaviour.upgradeSlots.iconNameElite;
			unitIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(140f / unitIcon.transform.localScale.x, 120f / unitIcon.transform.localScale.y);
			unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(multiplier);
		}
	}

	public override bool IsAvailable()
	{
		return !LevelManager.instance.isWarArenaLocked && (WarArena.instance.isOpened || WarArena.instance.isReminderTime);
	}

	public override IEnumerator Show(float time)
	{
		buttonCollider.enabled = true;
		if (!mIsRunning)
		{
			mIsRunning = true;
			mTimeWorker = RadicalRoutine.Create(TimerWorker());
			StartCoroutine(RadicalRoutine.Run(mTimeWorker.enumerator));
		}
		return base.Show(time);
	}

	public override IEnumerator Hide(float time)
	{
		buttonCollider.enabled = false;
		if (mIsRunning)
		{
			mIsRunning = false;
			mTimeWorker.Cancel();
		}
		return base.Hide(time);
	}

	private void UpdateAvailable()
	{
		mIsAvailable = IsAvailable();
		if (!mIsAvailable)
		{
			SetShowTimeEnd(0.5f);
			buttonCollider.enabled = false;
		}
	}

	private IEnumerator TimerWorker()
	{
		while (true)
		{
			int currentTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int arenaStartTime = ((WarArena.instance.warArenaConfig != null) ? WarArena.instance.warArenaConfig.start : 0);
			int arenaEndTime = ((WarArena.instance.warArenaConfig != null) ? WarArena.instance.warArenaConfig.end : 0);
			if (currentTime < arenaStartTime)
			{
				int time = arenaStartTime - currentTime;
				timeLabel.text = Localization.LocalizeFormat("ID_ARENAPROMOSTARTSIN", MiscTools.PrintableTime(time, "ID_READYTIME", string.Empty));
			}
			else if (currentTime < arenaEndTime)
			{
				int time2 = arenaEndTime - currentTime;
				timeLabel.text = Localization.LocalizeFormat("ID_ARENAPROMOENDSIN", MiscTools.PrintableTime(time2, "ID_READYTIME", string.Empty));
			}
			else
			{
				timeLabel.text = string.Empty;
			}
			float halfTimeLength = timeLabel.relativeSize.x * timeLabel.transform.localScale.x / 2f + 18f;
			leftWing.transform.localPosition = leftWing.transform.localPosition.ReplaceX(0f - halfTimeLength);
			rightWing.transform.localPosition = rightWing.transform.localPosition.ReplaceX(halfTimeLength);
			if (WarArena.instance.isExpired)
			{
				WarArena.instance.TryGetNewArena();
			}
			yield return new WaitForRealSeconds(0.333f);
		}
	}
}
