using UnityEngine;

public class ArenaVisualMessage : DatabaseMessage
{
	private PlayerVisual mVisual;

	private int mWonBattles;

	public ArenaVisualMessage(PlayerVisual visual, int wonBattles)
		: base("ArenaVisualMessage", Type.ArenaVisualMessage)
	{
		mVisual = visual;
		mWonBattles = wonBattles;
		messageId += $"-{mVisual.id}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
	}

	public override void Show()
	{
		base.Show();
		Debug.LogFormat("Show visual \"{0}\" tutorial - pop-up", mVisual.visualName);
		GuiElementSingle<ArenaCosmeticsDialog>.instance.ShowDialog(mVisual, mWonBattles);
	}
}
