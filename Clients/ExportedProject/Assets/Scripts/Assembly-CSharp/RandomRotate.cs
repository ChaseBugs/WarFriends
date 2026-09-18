using UnityEngine;

public class RandomRotate : MonoBehaviour
{
	private float _nextRotate;

	private float oldRotation;

	private void Start()
	{
	}

	private void Update()
	{
		if ((double)Random.value < 0.01 && Time.time > _nextRotate)
		{
			_nextRotate = Time.time + 1.1f;
			int num = Random.Range(-2, 2) * 360;
			TweenRotationSpecial.Begin(base.gameObject, 1.1f, Vector3.forward, oldRotation, num);
			oldRotation = num;
		}
	}
}
