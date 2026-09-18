using UnityEngine;

public class FTBL_DeadTime : MonoBehaviour
{
	public float deadTime;

	private void Awake()
	{
		Object.Destroy(base.gameObject, deadTime);
	}

	private void Update()
	{
	}
}
