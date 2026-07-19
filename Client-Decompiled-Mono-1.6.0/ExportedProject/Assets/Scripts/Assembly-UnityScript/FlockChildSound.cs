using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(AudioSource))]
public class FlockChildSound : MonoBehaviour
{
	public AudioClip[] _idleSounds;

	public float _idleSoundRandomChance;

	public AudioClip[] _flightSounds;

	public float _flightSoundRandomChance;

	public AudioClip[] _scareSounds;

	public float _pitchMin;

	public float _pitchMax;

	public float _volumeMin;

	public float _volumeMax;

	private FlockChild _flockChild;

	private AudioSource _audio;

	private bool _hasLanded;

	public FlockChildSound()
	{
		_idleSoundRandomChance = 0.05f;
		_flightSoundRandomChance = 0.05f;
		_pitchMin = 0.85f;
		_pitchMax = 1f;
		_volumeMin = 0.6f;
		_volumeMax = 0.8f;
	}

	public virtual void Start()
	{
		_flockChild = (FlockChild)GetComponent(typeof(FlockChild));
		_audio = (AudioSource)GetComponent(typeof(AudioSource));
		InvokeRepeating("PlayRandomSound", UnityEngine.Random.value + 1f, 1f);
		if (_scareSounds.Length > 0)
		{
			InvokeRepeating("ScareSound", 1f, 0.01f);
		}
	}

	public virtual void PlayRandomSound()
	{
		if (gameObject.activeInHierarchy)
		{
			if (!_audio.isPlaying && _flightSounds.Length > 0 && !(_flightSoundRandomChance <= UnityEngine.Random.value) && !_flockChild._landing)
			{
				_audio.clip = _flightSounds[UnityEngine.Random.Range(0, _flightSounds.Length)];
				_audio.pitch = UnityEngine.Random.Range(_pitchMin, _pitchMax);
				_audio.volume = UnityEngine.Random.Range(_volumeMin, _volumeMax);
				_audio.Play();
			}
			else if (!_audio.isPlaying && _idleSounds.Length > 0 && !(_idleSoundRandomChance <= UnityEngine.Random.value) && _flockChild._landing)
			{
				_audio.clip = _idleSounds[UnityEngine.Random.Range(0, _idleSounds.Length)];
				_audio.pitch = UnityEngine.Random.Range(_pitchMin, _pitchMax);
				_audio.volume = UnityEngine.Random.Range(_volumeMin, _volumeMax);
				_audio.Play();
				_hasLanded = true;
			}
		}
	}

	public virtual void ScareSound()
	{
		if (gameObject.activeInHierarchy && _hasLanded && !_flockChild._landing && !(_idleSoundRandomChance * 2f <= UnityEngine.Random.value))
		{
			_audio.clip = _scareSounds[UnityEngine.Random.Range(0, _scareSounds.Length)];
			_audio.volume = UnityEngine.Random.Range(_volumeMin, _volumeMax);
			_audio.PlayDelayed(UnityEngine.Random.value * 0.2f);
			_hasLanded = false;
		}
	}

	public virtual void Main()
	{
	}
}
