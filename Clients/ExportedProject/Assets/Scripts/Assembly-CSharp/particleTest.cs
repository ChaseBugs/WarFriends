using UnityEngine;

public class particleTest : MonoBehaviour
{
	public bool play;

	private void Start()
	{
	}

	private void Update()
	{
		if (play)
		{
			GetComponent<ParticleSystem>().Play();
			play = false;
		}
	}
}
