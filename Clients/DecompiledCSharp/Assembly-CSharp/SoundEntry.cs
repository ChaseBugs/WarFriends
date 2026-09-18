using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundEntry
{
	[HideInInspector]
	[SerializeField]
	public string Name = "undefined";

	[SerializeField]
	public float volume = 1f;

	public bool persistent = true;

	[SerializeField]
	private string mClipPath = string.Empty;

	[SerializeField]
	private string[] mClipPaths;

	private AudioClip mClip;

	private AudioClip[] mClips;

	private bool mUse;

	public void MarkAsUsed()
	{
		mUse = true;
	}

	public void Load()
	{
		if (!mUse && !persistent)
		{
			return;
		}
		if (mClip == null)
		{
			mClip = Resources.Load<AudioClip>(mClipPath);
		}
		if (mClips == null)
		{
			List<AudioClip> list = new List<AudioClip>();
			string[] array = mClipPaths;
			foreach (string path in array)
			{
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public void UnLoad()
	{
		if (mClip != null)
		{
			Resources.UnloadAsset(mClip);
		}
		if (mClips != null)
		{
			AudioClip[] array = mClips;
			foreach (AudioClip assetToUnload in array)
			{
				Resources.UnloadAsset(assetToUnload);
			}
		}
		mClip = null;
		mClips = null;
		mUse = false;
	}

	public AudioClip GetClip()
	{
		return (mClips == null || mClips.Length <= 0) ? mClip : mClips[UnityEngine.Random.Range(0, mClips.Length)];
	}
}
