using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public abstract class AmmoSetup : MonoBehaviour
{
	public ObscuredFloat damageAmount = 20f;

	public float hitForce = 20f;

	public ObscuredFloat criticalProbability = 0f;

	public ObscuredFloat criticalAmount = 2f;

	public ObscuredFloat damageToPlayerCoeficient = 1f;

	public ObscuredFloat damageToPlayerOvertimeCoeficient = 1f;

	public virtual void ScaleDamage(float scale)
	{
		damageAmount = (float)damageAmount * scale;
	}

	public virtual void Reset()
	{
	}
}
