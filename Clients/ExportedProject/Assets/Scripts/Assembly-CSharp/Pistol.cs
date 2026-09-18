public class Pistol : AutomaticRifle
{
	public override int ammoLeft
	{
		get
		{
			return int.MaxValue;
		}
		set
		{
		}
	}
}
