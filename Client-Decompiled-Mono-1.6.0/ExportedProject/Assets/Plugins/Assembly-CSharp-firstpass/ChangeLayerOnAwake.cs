using UnityEngine;

public class ChangeLayerOnAwake : MonoBehaviour
{
	public int layerNumber;

	private void Awake()
	{
		base.gameObject.layer = layerNumber;
	}
}
