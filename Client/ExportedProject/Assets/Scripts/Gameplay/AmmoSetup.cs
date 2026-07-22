using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class AmmoSetup : MonoBehaviour
{
	[FormerlySerializedAs("MPKEOMEFONA")]
	public ObscuredFloat EPDELOGPNAC = 20f;

	[FormerlySerializedAs("KOHJGCFDFMM")]
	public float JGGGDHJEIKB = 20f;

	[FormerlySerializedAs("ONAOPIGFDLM")]
	public ObscuredFloat NFKPBDGGDEA = 0f;

	[FormerlySerializedAs("AMGEKMEGKJC")]
	public ObscuredFloat FACEDCDFHJC = 2f;

	[FormerlySerializedAs("DOBABOBIAIF")]
	public ObscuredFloat NLCFDPBLBIG = 1f;

	[FormerlySerializedAs("MAFOJBJMLPN")]
	public ObscuredFloat ADKJBFFFCEH = 1f;

	public virtual void ScaleDamage(float IAJAILAGAKC)
	{
		EPDELOGPNAC = (float)EPDELOGPNAC * IAJAILAGAKC;
	}

	public virtual void Reset()
	{
	}
}
