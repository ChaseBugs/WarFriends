using UnityEngine;

public class VehicleEngine : MonoBehaviour
{
	public Sounds3DEnum startSound;

	public Sounds3DEnum loopSound;

	public Sounds3DEnum deathSound;

	public AudioSource audioSource;

	private bool mEngineStarted;

	private void Update()
	{
		if (mEngineStarted)
		{
			if (!audioSource.isPlaying)
			{
				audioSource.loop = true;
				Singleton<SoundsManager3D>.instance.Play(audioSource, loopSound);
			}
			if (Time.timeScale < 0.01f != audioSource.mute)
			{
				audioSource.mute = Time.timeScale < 0.01f;
			}
		}
	}

	public void StartEngine()
	{
		base.enabled = true;
		mEngineStarted = true;
		audioSource.loop = false;
		Singleton<SoundsManager3D>.instance.Play(audioSource, startSound);
	}

	public void OnDeath()
	{
		base.enabled = false;
		mEngineStarted = false;
		if (audioSource.isPlaying)
		{
			audioSource.Stop();
			audioSource.loop = false;
			Singleton<SoundsManager3D>.instance.Play(audioSource, deathSound);
		}
	}

	public void OnDestroy()
	{
		audioSource.Stop();
	}
}
