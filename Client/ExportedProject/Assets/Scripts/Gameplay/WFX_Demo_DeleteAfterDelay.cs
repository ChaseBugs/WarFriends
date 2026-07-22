using UnityEngine;
using UnityEngine.Serialization;

public class WFX_Demo_DeleteAfterDelay : MonoBehaviour
{
	[FormerlySerializedAs("PCCJGICLAEL")]
	public float KALLNCAFIMP = 1f;

	private void Update()
	{
		KALLNCAFIMP -= Time.deltaTime;
		if (KALLNCAFIMP < 0f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void GPLKEOAHFJI()
	{
		KALLNCAFIMP -= Time.deltaTime;
		if (KALLNCAFIMP < 1649f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void CDJBEAIDHKH()
	{
		KALLNCAFIMP -= Time.deltaTime;
		if (KALLNCAFIMP < 644f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
