using UnityEngine;

public class CountObjects : MonoBehaviour
{
	public bool count;

	private void Start()
	{
	}

	private void Update()
	{
		if (count)
		{
			count = false;
			CountChildren(base.transform);
			GameObject[] array = Object.FindObjectsOfType<GameObject>();
			Debug.Log("C: " + array.LongLength);
		}
	}

	private int CountChildren(Transform transform)
	{
		int num = 1;
		foreach (Transform item in transform)
		{
			num += CountChildren(item);
		}
		transform.name = transform.name + " (" + num + ")";
		return num;
	}
}
