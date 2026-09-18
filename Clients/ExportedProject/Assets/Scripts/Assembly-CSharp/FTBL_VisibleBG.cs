using UnityEngine;

public class FTBL_VisibleBG : MonoBehaviour
{
	public bool myCheck = true;

	public GameObject BG;

	private void Start()
	{
	}

	private void OnMouseDown()
	{
		if (myCheck)
		{
			BG.SetActive(value: false);
			myCheck = false;
		}
		else if (!myCheck)
		{
			BG.SetActive(value: true);
			myCheck = true;
		}
	}
}
