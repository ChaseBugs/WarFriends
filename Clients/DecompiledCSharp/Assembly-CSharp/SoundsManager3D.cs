using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SoundsManager3D : Singleton<SoundsManager3D>
{
	[Serializable]
	public class SoundEntry3D : SoundEntry
	{
		[SerializeField]
		public Sounds3DEnum soundEnum;
	}

	public List<SoundEntry3D> SoundEntries;

	private Dictionary<Sounds3DEnum, SoundEntry3D> mAllSounds;

	private AudioSource[] mSources;

	private int mCurrentIndex;

	public GameObject audioSourcesParent;

	protected override void Awake()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		base.Awake();
		mAllSounds = new Dictionary<Sounds3DEnum, SoundEntry3D>();
		foreach (SoundEntry3D soundEntry in SoundEntries)
		{
			mAllSounds[soundEntry.soundEnum] = soundEntry;
		}
		mSources = audioSourcesParent.GetComponentsInChildren<AudioSource>();
	}

	public void Play(Vector3 position, Sounds3DEnum soundEnum)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f))
		{
			AudioSource audioSource = mSources[mCurrentIndex];
			SoundEntry3D soundEntry3D = mAllSounds[soundEnum];
			audioSource.Stop();
			audioSource.clip = soundEntry3D.GetClip();
			audioSource.transform.position = position;
			audioSource.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			audioSource.spatialBlend = 1f;
			audioSource.Play();
			mCurrentIndex++;
			mCurrentIndex %= mSources.Length;
		}
	}

	public AudioSource Play(Vector3 position, AudioClip clip, float volume = 1f)
	{
		if (SoundsManager.Instance.soundsVolume < 0.05f)
		{
			return null;
		}
		AudioSource audioSource = mSources[mCurrentIndex];
		audioSource.Stop();
		audioSource.transform.position = position;
		audioSource.volume = 1f;
		audioSource.spatialBlend = 1f;
		audioSource.PlayOneShot(clip, volume * SoundsManager.Instance.soundsVolume);
		mCurrentIndex++;
		mCurrentIndex %= mSources.Length;
		return audioSource;
	}

	public void Play(GameObject go, Sounds3DEnum soundEnum)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f) && soundEnum != Sounds3DEnum.None)
		{
			AudioSource component = go.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = mAllSounds[soundEnum];
				component.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.clip = soundEntry3D.GetClip();
				component.spatialBlend = 1f;
				component.Play();
			}
		}
	}

	public void Play(AudioSource audioSource, Sounds3DEnum soundEnum, float volume = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f) && soundEnum != Sounds3DEnum.None && (bool)audioSource)
		{
			SoundEntry3D soundEntry3D = mAllSounds[soundEnum];
			audioSource.volume = volume * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			audioSource.clip = soundEntry3D.GetClip();
			audioSource.spatialBlend = 1f;
			audioSource.Play();
		}
	}

	public void PlayOneShot(GameObject go, Sounds3DEnum soundEnum, float volume = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f) && soundEnum != Sounds3DEnum.None)
		{
			AudioSource component = go.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = mAllSounds[soundEnum];
				component.volume = volume * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.spatialBlend = 1f;
				component.PlayOneShot(soundEntry3D.GetClip());
			}
		}
	}

	public void LoadNow(Sounds3DEnum soundEnum)
	{
		SoundEntry3D soundEntry3D = mAllSounds[soundEnum];
		soundEntry3D.MarkAsUsed();
		soundEntry3D.Load();
	}

	public void Play(AudioSource audioSource, AudioClip clip)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f) && (bool)audioSource)
		{
			audioSource.spatialBlend = 1f;
			audioSource.PlayOneShot(clip, SoundsManager.Instance.soundsVolume);
		}
	}

	public void LoadSounds()
	{
		foreach (SoundEntry3D soundEntry in SoundEntries)
		{
			soundEntry.Load();
		}
	}

	public void UnloadSounds()
	{
		foreach (SoundEntry3D soundEntry in SoundEntries)
		{
			soundEntry.UnLoad();
		}
	}

	public void UseSound(Sounds3DEnum sound)
	{
		if (mAllSounds.TryGetValue(sound, out var value))
		{
			value.MarkAsUsed();
		}
	}
}
