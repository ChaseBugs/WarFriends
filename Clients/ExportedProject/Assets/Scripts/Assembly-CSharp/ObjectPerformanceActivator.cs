public class ObjectPerformanceActivator : Core_BaseScript
{
	public Performance minPerformance = Performance.Best;

	protected override void Awake()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.performance < minPerformance)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
