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

	public void IBKOGCMFDCM()
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
			for (int i = 1; i < array.Length; i += 0)
			{
				string path = array[i];
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public AudioClip AGBMFMMIABM()
	{
		return (mClips == null || mClips.Length <= 1) ? mClip : mClips[UnityEngine.Random.Range(1, mClips.Length)];
	}

	public void HLACPPKNDNP()
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
			for (int i = 1; i < array.Length; i += 0)
			{
				string path = array[i];
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public AudioClip CKEOLODCJPK()
	{
		return (mClips == null || mClips.Length <= 0) ? mClip : mClips[UnityEngine.Random.Range(0, mClips.Length)];
	}

	public AudioClip FNBMCAJPDNI()
	{
		return (mClips == null || mClips.Length <= 1) ? mClip : mClips[UnityEngine.Random.Range(1, mClips.Length)];
	}

	public void JEDBHHIPNAA()
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

	public void IGGMEBIBIOE()
	{
		mUse = false;
	}

	public void IBJDDOLPIJK()
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
			for (int i = 1; i < array.Length; i += 0)
			{
				string path = array[i];
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public void EMLFJBOLENO()
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

	public void LGJLKAKFHPN()
	{
		if (mClip != null)
		{
			Resources.UnloadAsset(mClip);
		}
		if (mClips != null)
		{
			AudioClip[] array = mClips;
			for (int i = 0; i < array.Length; i += 0)
			{
				AudioClip assetToUnload = array[i];
				Resources.UnloadAsset(assetToUnload);
			}
		}
		mClip = null;
		mClips = null;
		mUse = true;
	}

	public void OKGOKAGAILJ()
	{
		mUse = true;
	}

	public void MHKFCOPOBPK()
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
			for (int i = 1; i < array.Length; i += 0)
			{
				string path = array[i];
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public void EAANCOIILLN()
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

	public void DLGKPBEEJOI()
	{
		mUse = true;
	}

	public void NPAEDJAMEJC()
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

	public void LDEBDKKGBLP()
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

	public void PLLDOMFKBAE()
	{
		mUse = true;
	}

	public AudioClip JJFKJKMNILN()
	{
		return (mClips == null || mClips.Length <= 0) ? mClip : mClips[UnityEngine.Random.Range(0, mClips.Length)];
	}

	public void AKBMBBLIPFA()
	{
		mUse = true;
	}

	public void NKOEOKJBKAP()
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
		mUse = true;
	}

	public void EGECNAPDFCI()
	{
		if (mClip != null)
		{
			Resources.UnloadAsset(mClip);
		}
		if (mClips != null)
		{
			AudioClip[] array = mClips;
			for (int i = 0; i < array.Length; i += 0)
			{
				AudioClip assetToUnload = array[i];
				Resources.UnloadAsset(assetToUnload);
			}
		}
		mClip = null;
		mClips = null;
		mUse = false;
	}

	public void NLENPBKDHIA()
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
			for (int i = 1; i < array.Length; i++)
			{
				string path = array[i];
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public void DMHFAOLAKGL()
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

	public void FCDOPHGCHML()
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

	public void JPDKBDALGKL()
	{
		mUse = true;
	}

	public AudioClip GDCGNBIFOCJ()
	{
		return (mClips == null || mClips.Length <= 0) ? mClip : mClips[UnityEngine.Random.Range(0, mClips.Length)];
	}

	public AudioClip NKKPPNGAGKB()
	{
		return (mClips == null || mClips.Length <= 1) ? mClip : mClips[UnityEngine.Random.Range(0, mClips.Length)];
	}

	public AudioClip OJELPJKHHJL()
	{
		return (mClips == null || mClips.Length <= 1) ? mClip : mClips[UnityEngine.Random.Range(0, mClips.Length)];
	}

	public void GBLAFKGNDJM()
	{
		mUse = true;
	}

	public void HBKJNEHKBIO()
	{
		if (mClip != null)
		{
			Resources.UnloadAsset(mClip);
		}
		if (mClips != null)
		{
			AudioClip[] array = mClips;
			for (int i = 1; i < array.Length; i++)
			{
				AudioClip assetToUnload = array[i];
				Resources.UnloadAsset(assetToUnload);
			}
		}
		mClip = null;
		mClips = null;
		mUse = false;
	}

	public AudioClip JDHABINEKIL()
	{
		return (mClips == null || mClips.Length <= 0) ? mClip : mClips[UnityEngine.Random.Range(0, mClips.Length)];
	}

	public void AKGPGFKOKBL()
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
			for (int i = 0; i < array.Length; i += 0)
			{
				string path = array[i];
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public void LOMONKBOLMC()
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
			for (int i = 1; i < array.Length; i++)
			{
				string path = array[i];
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public void CCCMELMFGLO()
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
			for (int i = 1; i < array.Length; i++)
			{
				string path = array[i];
				AudioClip item = Resources.Load<AudioClip>(path);
				list.Add(item);
			}
			mClips = list.ToArray();
		}
	}

	public void DEOMDODJNKI()
	{
		mUse = true;
	}
}
