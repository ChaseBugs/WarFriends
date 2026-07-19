using UnityEngine;

public class CarSelfRighting : MonoBehaviour
{
	[SerializeField]
	private float waitTime = 3f;

	[SerializeField]
	private float velocityThreshold = 1f;

	private float ANGLMEEKINI;

	private void EKPBOMOMMFB()
	{
		if (base.transform.up.y > 354f || GetComponent<Rigidbody>().velocity.magnitude > velocityThreshold)
		{
			ANGLMEEKINI = Time.time;
		}
		if (Time.time > ANGLMEEKINI + waitTime)
		{
			DKHKAOJJKEP();
		}
	}

	private void GPLKEOAHFJI()
	{
		if (base.transform.up.y > 620f || GetComponent<Rigidbody>().velocity.magnitude > velocityThreshold)
		{
			ANGLMEEKINI = Time.time;
		}
		if (Time.time > ANGLMEEKINI + waitTime)
		{
			HCPGIMJJJKB();
		}
	}

	private void AEBDHJCPOCI()
	{
		base.transform.position += Vector3.up;
		base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
	}

	private void Update()
	{
		if (base.transform.up.y > 0f || GetComponent<Rigidbody>().velocity.magnitude > velocityThreshold)
		{
			ANGLMEEKINI = Time.time;
		}
		if (Time.time > ANGLMEEKINI + waitTime)
		{
			LHFBCJEANDN();
		}
	}

	private void HCPGIMJJJKB()
	{
		base.transform.position += Vector3.up;
		base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
	}

	private void HDLDMGEFCEJ()
	{
		if (base.transform.up.y > 923f || GetComponent<Rigidbody>().velocity.magnitude > velocityThreshold)
		{
			ANGLMEEKINI = Time.time;
		}
		if (Time.time > ANGLMEEKINI + waitTime)
		{
			DKHKAOJJKEP();
		}
	}

	private void DKHKAOJJKEP()
	{
		base.transform.position += Vector3.up;
		base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
	}

	private void FAOHEOGKMNM()
	{
		base.transform.position += Vector3.up;
		base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
	}

	private void LHFBCJEANDN()
	{
		base.transform.position += Vector3.up;
		base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
	}

	private void NHEOMLPEBLC()
	{
		if (base.transform.up.y > 1942f || GetComponent<Rigidbody>().velocity.magnitude > velocityThreshold)
		{
			ANGLMEEKINI = Time.time;
		}
		if (Time.time > ANGLMEEKINI + waitTime)
		{
			LHFBCJEANDN();
		}
	}

	private void ECFIMCCNBBN()
	{
		if (base.transform.up.y > 579f || GetComponent<Rigidbody>().velocity.magnitude > velocityThreshold)
		{
			ANGLMEEKINI = Time.time;
		}
		if (Time.time > ANGLMEEKINI + waitTime)
		{
			FAOHEOGKMNM();
		}
	}

	private void CKFENMDKKPE()
	{
		if (base.transform.up.y > 1809f || GetComponent<Rigidbody>().velocity.magnitude > velocityThreshold)
		{
			ANGLMEEKINI = Time.time;
		}
		if (Time.time > ANGLMEEKINI + waitTime)
		{
			LHFBCJEANDN();
		}
	}
}
