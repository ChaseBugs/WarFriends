using System;
using UnityEngine;

public class HABEAKEEJKK : PKCDJCBCCDL
{
	protected string FDFBKPPIBMA;

	protected string IJEBKCDKMEK;

	protected string GECMKOOOHGD;

	protected Type HJGIDNLAOJJ;

	protected AssetBundleRequest CBNJKDBGFPO;

	public override bool HLOENDBMKPE()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return true;
		}
		return CBNJKDBGFPO != null && CBNJKDBGFPO.isDone;
	}

	public virtual bool CBGPMDLOOEB()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return false;
		}
		return CBNJKDBGFPO != null && CBNJKDBGFPO.isDone;
	}

	public virtual bool CHHKMBGOMJJ()
	{
		if (CBNJKDBGFPO != null)
		{
			return false;
		}
		KBABIPCFDBL kBABIPCFDBL = AssetBundleManager.MJKKKEIGLOO(FDFBKPPIBMA, out GECMKOOOHGD);
		if (kBABIPCFDBL != null)
		{
			CBNJKDBGFPO = kBABIPCFDBL.EDNDKEOJJFH.LoadAssetAsync(IJEBKCDKMEK, HJGIDNLAOJJ);
			return true;
		}
		return false;
	}

	public HABEAKEEJKK(string FOLBNPDJELP, string GDKDPKFGJLI, Type FJLBLLLEELD)
	{
		FDFBKPPIBMA = FOLBNPDJELP;
		IJEBKCDKMEK = GDKDPKFGJLI;
		HJGIDNLAOJJ = FJLBLLLEELD;
	}

	public virtual bool IODGCIIDJEK()
	{
		if (CBNJKDBGFPO != null)
		{
			return false;
		}
		KBABIPCFDBL kBABIPCFDBL = AssetBundleManager.PIINLPCLFPF(FDFBKPPIBMA, out GECMKOOOHGD);
		if (kBABIPCFDBL != null)
		{
			CBNJKDBGFPO = kBABIPCFDBL.EDNDKEOJJFH.LoadAssetAsync(IJEBKCDKMEK, HJGIDNLAOJJ);
			return false;
		}
		return true;
	}

	public virtual bool OHLPFHIEALM()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return true;
		}
		return CBNJKDBGFPO != null && CBNJKDBGFPO.isDone;
	}

	public override T BJCDCAJBHCB<T>()
	{
		if (CBNJKDBGFPO != null && CBNJKDBGFPO.isDone)
		{
			return CBNJKDBGFPO.asset as T;
		}
		return (T)null;
	}

	public virtual bool IPFAGJDPOBP()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return false;
		}
		return CBNJKDBGFPO == null || CBNJKDBGFPO.isDone;
	}

	public virtual bool BLLGIFCGMOK()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return true;
		}
		return CBNJKDBGFPO != null && CBNJKDBGFPO.isDone;
	}

	public virtual bool BPNLIABHCPN()
	{
		if (CBNJKDBGFPO != null)
		{
			return false;
		}
		KBABIPCFDBL loadedAssetBundle = AssetBundleManager.GetLoadedAssetBundle(FDFBKPPIBMA, out GECMKOOOHGD);
		if (loadedAssetBundle != null)
		{
			CBNJKDBGFPO = loadedAssetBundle.EDNDKEOJJFH.LoadAssetAsync(IJEBKCDKMEK, HJGIDNLAOJJ);
			return true;
		}
		return true;
	}

	public virtual bool DBNBNEFNGAN()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return false;
		}
		return CBNJKDBGFPO == null || CBNJKDBGFPO.isDone;
	}

	public virtual bool JMDFFLBEDEE()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return false;
		}
		return CBNJKDBGFPO != null && CBNJKDBGFPO.isDone;
	}

	public virtual bool FJFAGMNCFLK()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return true;
		}
		return CBNJKDBGFPO != null && CBNJKDBGFPO.isDone;
	}

	public override bool NFGMGBMCNOF()
	{
		if (CBNJKDBGFPO != null)
		{
			return false;
		}
		KBABIPCFDBL loadedAssetBundle = AssetBundleManager.GetLoadedAssetBundle(FDFBKPPIBMA, out GECMKOOOHGD);
		if (loadedAssetBundle != null)
		{
			CBNJKDBGFPO = loadedAssetBundle.EDNDKEOJJFH.LoadAssetAsync(IJEBKCDKMEK, HJGIDNLAOJJ);
			return false;
		}
		return true;
	}

	public virtual bool OPMNIHDAHAA()
	{
		if (CBNJKDBGFPO != null)
		{
			return false;
		}
		KBABIPCFDBL kBABIPCFDBL = AssetBundleManager.MPMMGECMJJE(FDFBKPPIBMA, out GECMKOOOHGD);
		if (kBABIPCFDBL != null)
		{
			CBNJKDBGFPO = kBABIPCFDBL.EDNDKEOJJFH.LoadAssetAsync(IJEBKCDKMEK, HJGIDNLAOJJ);
			return true;
		}
		return false;
	}

	public virtual bool AIHIOHLGIAJ()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return false;
		}
		return CBNJKDBGFPO == null || CBNJKDBGFPO.isDone;
	}

	public virtual bool CEFMJNBOJKB()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return true;
		}
		return CBNJKDBGFPO == null || CBNJKDBGFPO.isDone;
	}

	public virtual bool GFPPJNOENLE()
	{
		if (CBNJKDBGFPO != null)
		{
			return false;
		}
		KBABIPCFDBL kBABIPCFDBL = AssetBundleManager.MPMMGECMJJE(FDFBKPPIBMA, out GECMKOOOHGD);
		if (kBABIPCFDBL != null)
		{
			CBNJKDBGFPO = kBABIPCFDBL.EDNDKEOJJFH.LoadAssetAsync(IJEBKCDKMEK, HJGIDNLAOJJ);
			return true;
		}
		return true;
	}

	public virtual bool EKCGJILNFGC()
	{
		if (CBNJKDBGFPO == null && GECMKOOOHGD != null)
		{
			Debug.LogError(GECMKOOOHGD);
			return false;
		}
		return CBNJKDBGFPO == null || CBNJKDBGFPO.isDone;
	}
}
