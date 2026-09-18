public class PlayerHealthBars : GuiElementSingle<PlayerHealthBars>
{
	public PlayerHealthBarGuiElement playerHealthBar;

	public PlayerHealthBarGuiElement opponentHealthBar;

	public override void InitControls()
	{
		Singleton<GameCamera>.instance.AnimationFinished += InstanceOnAnimationFinished;
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += InstanceOnAnimationOnPlayerStop;
		Singleton<GameCamera>.instance.SingleAnimationFinished += InstanceOnSingleAnimationFinished;
		playerHealthBar.Init();
		opponentHealthBar.Init();
	}

	public override void InitGUIValues()
	{
		playerHealthBar.Hide();
		opponentHealthBar.Hide();
	}

	private void InstanceOnAnimationOnPlayerStop()
	{
		opponentHealthBar.ShowUp();
	}

	private void InstanceOnAnimationFinished()
	{
		playerHealthBar.ShowUp();
	}

	private void InstanceOnSingleAnimationFinished()
	{
		playerHealthBar.ShowUp();
		if (Singleton<GameController>.instance.isMission && MissionsManager.instance.currentMission is BotMission)
		{
			opponentHealthBar.ShowUp();
		}
	}

	public void TutorialShowPlayer()
	{
		playerHealthBar.FakeGameStartedAndShowUp();
	}

	public void TutorialShowEnemy()
	{
		opponentHealthBar.FakeGameStartedAndShowUp();
	}
}
