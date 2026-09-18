using UnityEngine;

public class PlayerMinigunWeaponMotor : MonoBehaviour
{
	private enum State
	{
		Stopped,
		Starting,
		Looping,
		Stopping
	}

	public AudioSource audioSource;

	public AudioClip startSound;

	public AudioClip loopSound;

	public AudioClip stopSound;

	private State mState;

	public void StartMotor()
	{
		mState = State.Starting;
		audioSource.loop = false;
		audioSource.clip = startSound;
		audioSource.Play();
	}

	public void StopMotor()
	{
		if (mState == State.Starting || mState == State.Looping)
		{
			mState = State.Stopping;
			audioSource.loop = false;
			audioSource.clip = stopSound;
			audioSource.Play();
		}
	}

	private void Update()
	{
		switch (mState)
		{
		case State.Stopped:
			break;
		case State.Starting:
			if (!audioSource.isPlaying)
			{
				mState = State.Looping;
				audioSource.loop = true;
				audioSource.clip = loopSound;
				audioSource.Play();
			}
			break;
		case State.Looping:
			break;
		case State.Stopping:
			if (!audioSource.isPlaying)
			{
				mState = State.Stopped;
				audioSource.Stop();
				audioSource.loop = false;
				audioSource.clip = null;
			}
			break;
		}
	}
}
