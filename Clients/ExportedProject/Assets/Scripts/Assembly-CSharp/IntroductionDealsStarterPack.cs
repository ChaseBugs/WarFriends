using System;
using System.Collections;
using UnityEngine;

public class IntroductionDealsStarterPack : IntroductionDealsItem
{
	[Header("Starter Pack")]
	public Collider buttonCollider;

	public UILabel saleLabel;

	public UILabel timer;

	private bool mIsAvailable;

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
		GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.DialogType.STARTER_PACK);
		SetShowTimeEnd(0.5f);
	}

	private void DataLoaded(DatabaseAction action)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && action == DatabaseAction.BuyPack)
		{
			UpdateAvailable();
		}
	}

	public override void InitGuiValues()
	{
		base.InitGuiValues();
		float num = Singleton<GameVariables>.instance.SaleOfPack(CardPack.Starter);
		saleLabel.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(num * 100f));
		UpdateAvailable();
	}

	public override bool IsAvailable()
	{
		return PlayerAnalytics.instance.showStarterPack;
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
			int starterPackTimeOffer = PlayerAnalytics.instance.data.starterPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			timer.text = string.Format("{0} {1}{2}", Localization.Localize("ID_OFFERACTIVE"), Colours.stringBlue, MiscTools.PrintableTime(starterPackTimeOffer, "-", string.Empty));
			yield return new WaitForRealSeconds(0.333f);
		}
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
}
