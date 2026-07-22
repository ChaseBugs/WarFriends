public class DestroyableObjectMultipleParts : DestroyableObject
{
	public DestroyableObjectpart[] APECCAGGEND;

	public override bool showHitParticles
	{
		set
		{
		}
	}

	protected override void Awake()
	{
	}

	public override bool DoDamage(LDOKCBNNLCH INADGPICPMO, DestroyableObject KIHIFIBOOIM)
	{
		return false;
	}

	public void ResetWeights()
	{
	}

	public override void ChangeLayer(HPHFGNJPDKN LBHJBBKENEO, bool FDLHOKMOIFJ)
	{
	}

	[PunRPC]
	protected override void SetShowHitParticlesRPC(bool HHDCBKDKICG)
	{
	}
}
