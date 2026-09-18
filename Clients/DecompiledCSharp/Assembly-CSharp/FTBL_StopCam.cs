using UnityEngine;

public class FTBL_StopCam : MonoBehaviour
{
	public bool myCheck = true;

	public GameObject camObject;

	private Animator camAnim;

	private void Start()
	{
		camAnim = camObject.GetComponent<Animator>();
	}

	private void OnMouseDown()
	{
		if (myCheck)
		{
			camAnim.speed = 0f;
			myCheck = false;
		}
		else if (!myCheck)
		{
			camAnim.speed = 1f;
			myCheck = true;
		}
	}
}
