using System;
using System.Collections;
using UnityEngine;

public class IntroductionDealsStarterAssignments : IntroductionDealsItem
{
	[Header("Starter Assignments")]
	public Collider buttonCollider;

	public UILabel timer;

	private bool mIsAvailable = true;

	private bool mIsRunning;

	private RadicalRoutine mTimeWorker;

	public override void InitEvents()
	{
		base.InitEvents();
		buttonCollider.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(buttonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnButtonClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += DataLoaded;
	}

	private void OnButtonClick(GameObject go)
	{
		Debug.Log("OnButtonClick");
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<StarterAssignmentDialog>.instance, 0f);
		SetShowTimeEnd(0.5f);
	}

	private void DataLoaded(DatabaseAction action)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && (action == DatabaseAction.ClaimStarterAssignment || action == DatabaseAction.CompleteStarterAssignments))
		{
			UpdateAvailable();
		}
	}

	public override void InitGuiValues()
	{
		base.InitGuiValues();
		UpdateAvailable();
	}

	public override bool IsAvailable()
	{
		return mIsAvailable;
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

	private IEnumerator TimerWorker()
	{
		while (true)
		{
			timer.text = string.Format("{0} {1}{2}", Localization.Localize("ID_COMPLETEIN"), Colours.stringBlue, MiscTools.PrintableTime(StarterAssignmentsManager.instance.remainingTime, "ID_READYTIME", string.Empty));
			yield return new WaitForRealSeconds(0.333f);
		}
	}

	private void UpdateAvailable()
	{
		mIsAvailable = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		if (!mIsAvailable)
		{
			SetShowTimeEnd(0.5f);
			buttonCollider.enabled = false;
		}
	}
}
