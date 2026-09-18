public class GameTypeDependObject : Core_BaseScript
{
	[BitMask(typeof(GameController.GameType))]
	public GameController.GameType type;

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
	}

	private void OnDisable()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= InstanceOnGameStarted;
		}
	}

	private void OnDestroy()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= InstanceOnGameStarted;
		}
	}

	private void InstanceOnGameStarted()
	{
		GameController.GameType gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((type & gameType) == gameType);
		}
	}
}
