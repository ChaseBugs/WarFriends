public class DestroyableObjectPlayerPart : DestroyableObjectpart
{
	protected override bool playParticles => health > 0f;
}
