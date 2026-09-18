using UnityEngine;

public class testBundlePlugin : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("BundleVersion: " + BundleVersionBindings.BundleID);
		if ((bool)GetComponent<GUIText>())
		{
			GetComponent<GUIText>().text = BundleVersionBindings.BundleID;
		}
	}
}
