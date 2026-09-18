using UnityEngine;

public class HeaderTicketsButton : GuiElementSingle<HeaderTicketsButton>
{
	[Header("Core")]
	[SerializeField]
	private UILabel mTicketsLabel;

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += OnTicketsChanged;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
	}

	private void OnTicketsChanged(long amount, long diff)
	{
		if (isShowed)
		{
			if (diff == 0L)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 0f, new LongObject(amount), new LongObject(amount));
			}
			else
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 2f, new LongObject(amount - diff), new LongObject(amount));
			}
		}
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MiscTools.FormatBigNumber(Singleton<Wallet>.instance.tickets);
		}
	}
}
