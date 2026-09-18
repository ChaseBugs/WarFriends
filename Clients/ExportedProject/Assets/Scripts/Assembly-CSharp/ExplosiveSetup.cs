using UnityEngine.Serialization;

public class ExplosiveSetup : AmmoSetup
{
	[FormerlySerializedAs("playerDamageRatio")]
	public float playerBehindShieldRatio = 0.3f;
}
